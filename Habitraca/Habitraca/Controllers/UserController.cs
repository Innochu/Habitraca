using Habitraca.Application.Interface.Service;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
           {
           return Ok(await _userService.DeleteUser(Id));
        }
    }
}
