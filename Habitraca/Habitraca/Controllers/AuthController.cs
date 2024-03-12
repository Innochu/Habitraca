using Habitraca.Application.AuthEntity;
using Habitraca.Application.Interface.Service;
using Habitraca.Domain;
using Habitraca.Domain.AuthEntity;
using Microsoft.AspNetCore.Mvc;

namespace Habitraca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
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

    }
}
