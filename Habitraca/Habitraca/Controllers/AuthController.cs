using Habitraca.Domain.AuthEntity;
using Microsoft.AspNetCore.Mvc;

namespace Habitraca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _authenticationService.LoginAsync(loginDTO));
        }

    }
}
