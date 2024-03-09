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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
                return Ok(registrationResult);
            }
            return BadRequest(new { Message = registrationResult.Message, Errors = registrationResult.Errors });
            

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
