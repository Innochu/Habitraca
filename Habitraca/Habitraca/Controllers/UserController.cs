using Habitraca.Application.Interface.Service;
using Habitraca.Application.Services;
using Habitraca.Domain;
using Habitraca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Habitraca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

         private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
           return Ok(await _userService.DeleteUser(Id));
        }

        [HttpPut("Deactivate/{id}")]
        public async Task<IActionResult> Deactivate(string id)
        {
            var result = await _userService.DeactivateUser(id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
         
        [HttpPut("Activate/{id}")]
        public async Task<IActionResult> Activate(string id)
        {
            var result = await _userService.ActivateUser(id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("UserName/{id}")]
        public async Task<IActionResult> DisplayUserName(string id)
        {
         var result = await _authService.DisplayUserName(id);
         if (result.Succeeded)
         {
            return Ok(result);
         }
         else
         {
            return BadRequest(result);
         }
        }
    }
}
