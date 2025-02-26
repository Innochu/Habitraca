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
             return Ok(await _authService.RegisterAsync(userSignup));
             
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login loginDTO)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ApiResponse<string>.Failed("Invalid model state.", 400, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
           var response = await _authService.LoginAsync(loginDTO);
            if (response.Succeeded)
            {
                return Ok(new ApiResponse<string>(true, response.Message, response.StatusCode, null, new List<string>()));
            }
            else
            {
                return BadRequest(new ApiResponse<string>(false, response.Message, response.StatusCode, null, response.Errors));
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                return Ok(new ApiResponse<string>(true, "Logout successful", 200, null, new List<string>()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "An error occurred during logout", 500, ex.Message, null));
            }
        }

        // [HttpPost("reset-password")]
        // public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         var errors = ModelState.Values
        //             .SelectMany(v => v.Errors)
        //             .Select(e => e.ErrorMessage)
        //             .ToList();

        //         return BadRequest(new ApiResponse<string>(false, "Invalid model state.", 400, null, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
        //     }

        //     var response = await _authService.ResetPasswordAsync(model.Email, model.Token, model.NewPassword);

        //     if (response.Succeeded)
        //     {
        //         return Ok(new ApiResponse<string>(true, response.Message, response.StatusCode, null, new List<string>()));
        //     }
        //     else
        //     {
        //         return BadRequest(new ApiResponse<string>(false, response.Message, response.StatusCode, null, response.Errors));
        //     }

        // }
        //     [HttpPost("forgot-password")]
        // public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(new ApiResponse<string>(false, "Invalid model state.", 400, null, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
        //     }

        //     var response = await _authService.ForgotPasswordAsync(model.Email);

        //     if (response.Succeeded)
        //     {
        //         return Ok(new ApiResponse<string>(true, response.Message, response.StatusCode, null, new List<string>()));
        //     }
        //     else
        //     {
        //         return BadRequest(new ApiResponse<string>(false, response.Message, response.StatusCode, null, response.Errors));
        //     }
        // }
    }
}
