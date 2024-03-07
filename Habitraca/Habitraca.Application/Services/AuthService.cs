using Habitraca.Application.DtoFolder;
using Habitraca.Domain.AuthEntity;
using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Savi_Thrift.Application.Interfaces.Repositories;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Habitraca.Application.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;

        public AuthService( UserManager<User> userManager, SignInManager<User> signInManager)
        {
           
            _userManager = userManager;
          
            _signInManager = signInManager;
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
		private string GenerateJwtToken(User contact, string roles)
		{
			var jwtSettings = _config.GetSection("JwtSettings:Secret").Value;
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, contact.Id),
				new Claim(JwtRegisteredClaimNames.Email, contact.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.GivenName, contact.FirstName+" "+contact.LastName),
				new Claim(ClaimTypes.Role, roles)
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
