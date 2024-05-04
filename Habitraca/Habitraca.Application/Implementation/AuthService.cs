using Habitraca.Application.DtoFolder;
using Habitraca.Domain.AuthEntity;
using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Habitraca.Application.Interfaces.Repositories;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Habitraca.Application.Interface.Service;
using Habitraca.Domain;
using Microsoft.AspNetCore.Http;
using System.Web;
using Habitraca.Application.AuthEntity;
using Habitraca.Application.Implementation;
using Habitraca.Domain.EmailFolder;

namespace Habitraca.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config,
            IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<ApiResponse<RegisterResponseDto>> RegisterAsync(SignUp userSignup)
        {
            if (userSignup == null)
            {
                return ApiResponse<RegisterResponseDto>.Failed("Invalid user signup data.", StatusCodes.Status400BadRequest, new List<string>());
            }

            var user = await _userManager.FindByEmailAsync(userSignup.Email);
            if (user != null)
            {
                return ApiResponse<RegisterResponseDto>.Failed("User with this email already exists.", StatusCodes.Status400BadRequest, new List<string>());
            }

            var userr = await _unitOfWork.UserRepository.FindAsync(x => x.PhoneNumber == userSignup.PhoneNumber);
            if (userr.Count > 0)
            {
                return ApiResponse<RegisterResponseDto>.Failed("User with this phone number already exists.", StatusCodes.Status400BadRequest, new List<string>());
            }

            var appUser = new User()
            {
                FirstName = userSignup.FirstName,
                LastName = userSignup.LastName,
                Email = userSignup.Email,
                PhoneNumber = userSignup.PhoneNumber,
                UserName = userSignup.Email,
                PasswordResetToken = ""
            };

            try
            {
                var token = "";

                var result = await _userManager.CreateAsync(appUser, userSignup.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "User");
                    token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    token = HttpUtility.UrlEncode(token);

                    var generatedUsername = GenerateUniqueUsername(appUser.FirstName, appUser.LastName);

                    // Update the user object with the generated username
                    appUser.UserName = generatedUsername;

                    var response = new RegisterResponseDto()
                    {
                        Id = appUser.Id,
                        Email = appUser.Email,
                        PhoneNumber = appUser.PhoneNumber,
                        FirstName = appUser.FirstName,
                        LastName = appUser.LastName,
                        Token = token,
                        Username = generatedUsername
                    };

                    return ApiResponse<RegisterResponseDto>.Success(response, "User registered successfully. Please click on the link sent to your email to confirm your account", StatusCodes.Status201Created);

                }
                else
                {
                    return ApiResponse<RegisterResponseDto>.Failed("Error occurred: Failed to Create User", StatusCodes.Status400BadRequest, new List<string>());

                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error occurred while adding a manager " + ex.InnerException);
                return ApiResponse<RegisterResponseDto>.Failed("Error creating user." + ex.InnerException, StatusCodes.Status500InternalServerError, new List<string>());
            }
        }
        private string GenerateUniqueUsername(string firstName, string lastName)
        {
            // Generate a username based on the user's first and last name
            string username = $"{lastName.Substring(0, 1)}-{firstName}";

            // Check if the username already exists
            var existingUser = _userManager.Users.FirstOrDefault(u => u.UserName == username);

            // If the username already exists, add a number to the end of the username
            if (existingUser != null)
            {
                int i = 2;
                while (true)
                {
                    existingUser = _userManager.Users.FirstOrDefault(u => u.UserName == $"{username}{i}");
                    if (existingUser == null)
                    {
                        username += i;
                        break;
                    }
                    i++;
                }
            }

            return username;
        }
        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(Login loginDTO)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null)
                {
                    return ApiResponse<LoginResponseDto>.Failed("User not found.", StatusCodes.Status404NotFound, new List<string>());
                }

                var activeUser = await _unitOfWork.UserRepository.FindAsync(x => x.IsActive == true);
                if (activeUser == null)
                {
                    return ApiResponse<LoginResponseDto>.Failed("User is deactivated", StatusCodes.Status400BadRequest, new List<string>());
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, lockoutOnFailure: false);

                switch (result)
                {
                    case { Succeeded: true }:
                        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                        if (role == null)
                        {
                            return ApiResponse<LoginResponseDto>.Failed("Roles not found.", StatusCodes.Status400BadRequest, new List<string>());
                        }

                        var response = new LoginResponseDto
                        {
                            JWToken = GenerateJwtToken(user, role)

                        };

                        return ApiResponse<LoginResponseDto>.Success(response, "Logged In Successfully", StatusCodes.Status200OK);

                    case { IsLockedOut: true }:
                        return ApiResponse<LoginResponseDto>.Failed($"Account is locked out. Please try again later or contact support." +
                            $" You can unlock your account after {_userManager.Options.Lockout.DefaultLockoutTimeSpan.TotalMinutes} minutes.", StatusCodes.Status403Forbidden, new List<string>());

                    case { RequiresTwoFactor: true }:
                        return ApiResponse<LoginResponseDto>.Failed("Two-factor authentication is required.", StatusCodes.Status401Unauthorized, new List<string>());

                    case { IsNotAllowed: true }:
                        return ApiResponse<LoginResponseDto>.Failed("Login failed. Email confirmation is required.", StatusCodes.Status401Unauthorized, new List<string>());

                    default:
                        return ApiResponse<LoginResponseDto>.Failed("Login failed. Invalid email or password.", StatusCodes.Status401Unauthorized, new List<string>());
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<LoginResponseDto>.Failed("Some error occurred while logging in." + ex.InnerException, StatusCodes.Status500InternalServerError, new List<string>());
            }
        }
        private string GenerateJwtToken(User user, string role)
        {
            var jwtSettings = _config.GetSection("JwtSettings:Secret").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName+" "+user    .LastName),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _config.GetValue<string>("JwtSettings:ValidIssuer"),
                audience: _config.GetValue<string>("JwtSettings:ValidAudience"),
                //issuer: null,
                //audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config.GetSection("JwtSettings:AccessTokenExpiration").Value)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found.", 404, null, new List<string>());
                }

                // Additional token validation logic can be added here

                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (result.Succeeded)
                {
                    // Update user properties if needed
                    user.PasswordResetToken = null;
                    user.ResetTokenExpires = default;
                    await _userManager.UpdateAsync(user);

                    return new ApiResponse<string>(true, "Password reset successful.", 200, null, new List<string>());
                }
                else
                {
                    return new ApiResponse<string>(false, "Password reset failed.", 400, null, result.Errors.Select(error => error.Description).ToList());
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "Error occurred while resetting password for user with email {Email}", email);
                var errorList = new List<string> { "An unexpected error occurred while resetting the password." };
                return new ApiResponse<string>(true, "Error occurred while resetting password", 500, null, errorList);
            }
        }
        public async Task<ApiResponse<string>> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            try
            {
                var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

                if (result.Succeeded)
                {
                    return new ApiResponse<string>(true, "Password changed successfully.", 200, null, new List<string>());
                }
                else
                {
                    return new ApiResponse<string>(false, "Password change failed.", 400, null, result.Errors.Select(error => error.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error occurred while changing password");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(true, "Error occurred while changing password", 500, null, errorList);
            }
        }
        public async Task<ApiResponse<string>> ForgotPasswordAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found or email not confirmed.", StatusCodes.Status404NotFound, null, new List<string>());
                }

                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                token = HttpUtility.UrlEncode(token);
                user.PasswordResetToken = token;
                user.ResetTokenExpires = DateTime.UtcNow.AddHours(24);
                await _userManager.UpdateAsync(user);

                var resetPasswordUrl = "https://localhost:7226/api/Authentication/reset-password?email=" + Uri.EscapeDataString(email) + "&token=" + token;

                var mailRequest = new EmailEntity
                {
                    ReceiverEmail = email,
                    Subject = "Habit-Trac Password Reset Instructions",
                    Body = $"Please reset your password by clicking <a href='{resetPasswordUrl}'>here</a>."
                };

                await _emailService.SendMailAsync(mailRequest);

                return new ApiResponse<string>(true, "Password reset email sent successfully.", 200, null, new List<string>());
            }
            catch (Exception )
            {
                // _logger.LogError(ex, "Error occurred while processing forgot password for user with email {Email}", email);
                var errorList = new List<string> { "An unexpected error occurred while processing the forgot password request." };
                return new ApiResponse<string>(false, "Error occurred while processing forgot password", 500, null, errorList);
            }
        }
    }
}