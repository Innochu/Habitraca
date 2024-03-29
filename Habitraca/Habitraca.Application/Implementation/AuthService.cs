﻿using Habitraca.Application.DtoFolder;
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

namespace Habitraca.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
			_config = config;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<RegisterResponseDto>> RegisterAsync(SignUp userSignup)
        {
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
                    //token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    //token = HttpUtility.UrlEncode(token);
                   
                
                        var response = new RegisterResponseDto()
                        {
                            Id = appUser.Id,
                            Email = appUser.Email,
                            PhoneNumber = appUser.PhoneNumber,
                            FirstName = appUser.FirstName,
                            LastName = appUser.LastName,
                            Token = token
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
                return ApiResponse<RegisterResponseDto>.Failed("Error creating user.", StatusCodes.Status500InternalServerError, new List<string>() { ex.InnerException.ToString() });
            }
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
				var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, lockoutOnFailure: false);

				switch (result)
				{
					case { Succeeded: true }:
						var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
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
				return ApiResponse<LoginResponseDto>.Failed("Some error occurred while loggin in." + ex.InnerException, StatusCodes.Status500InternalServerError, new List<string>());
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

    }
}
