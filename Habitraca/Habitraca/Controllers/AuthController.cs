using Habitraca.Application.AuthEntity;
using Habitraca.Application.DtoFolder;
using Habitraca.Application.Interface.Service;
using Habitraca.Domain;
using Habitraca.Domain.AuthEntity;
using Habitraca.Domain.EmailFolder;
using Habitraca.Domain.Entities;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Habitraca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IAuthService authService, IEmailService emailService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SignUp userSignup)
        {
            if (!ModelState.IsValid)
             {
                return BadRequest(ApiResponse<string>.Failed("Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            // Call registration service
            var registrationResult = await _authService.RegisterAsync(userSignup);

            if (registrationResult.Succeeded)
            {
                var data = registrationResult.Data;
             
                var confirmationLink = GenerateConfirmEmailLink(data.Id, data.Token);
                if (confirmationLink != null)
                {
                    await _emailService.EmailConfirmation(confirmationLink, data.Email);
                    return Ok(data);
                }
                else
                {
                  //  await _userService.DeleteUser(data.Id);
                    return Ok("Email sending error: Confirmation link is null");
                }
            }
            else
            {
                return BadRequest(new { Message = registrationResult.Message, Errors = registrationResult.Errors });
            }
           
            

        }

        private static string GenerateConfirmEmailLink(string id, string token)
        {
            var cemail = "https://localhost:7226/api/account/confirm-email?UserId=" + id + "&token=" + token;
            return cemail;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login loginDTO)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ApiResponse<string>.Failed("Invalid model state.", 400, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
            return Ok(await _authService.LoginAsync(loginDTO));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Get the current user's email
                var userEmail = HttpContext.User.Identity.Name;

                // Sign out the user
                await _signInManager.SignOutAsync();
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                // Prepare the email notification with the user's email
                var emailEntity = new EmailEntity
                {
                    ReceiverEmail = userEmail,
                    Subject = "Logout Notification",
                    Body = "You have successfully logged out! Thank you for using Habitrac-Paddy."
                };

                // Send the email notification
                await _emailService.SendMailAsync(emailEntity);

                return Ok(new ApiResponse<string>(true, "Logout successful", 200, null, new List<string>()));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred during logout", 500, ex.Message, null));
            }
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto model, [FromHeader(Name = "Authorization")] string authToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", 400, null, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            if (string.IsNullOrWhiteSpace(authToken))
            {
                return Unauthorized(new ApiResponse<string>(false, "Authorization token is missing.", 401, null, new List<string>()));
            }

            var userIdResponse = _authService.ExtractUserIdFromToken(authToken);

            if (!userIdResponse.Succeeded)
            {
                return Unauthorized(userIdResponse);
            }
            var userId = userIdResponse.Data;

            var user = await _userManager.FindByEmailAsync(userId);

            if (user == null)
            {
                return Unauthorized(new ApiResponse<string>(false, "User not found.", 401, null, new List<string>()));
            }

            var response = await _authService.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (response.Succeeded)
            {
                return Ok(new ApiResponse<string>(true, response.Message, response.StatusCode, null, new List<string>()));
            }
            else
            {
                return BadRequest(new ApiResponse<string>(false, response.Message, response.StatusCode, null, response.Errors));
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", 400, null, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }

            var response = await _authService.ForgotPasswordAsync(model.Email);

            if (response.Succeeded)
            {
                return Ok(new ApiResponse<string>(true, response.Message, response.StatusCode, null, new List<string>()));
            }
            else
            {
                return BadRequest(new ApiResponse<string>(false, response.Message, response.StatusCode, null, response.Errors));
            }
        }
    }
}
