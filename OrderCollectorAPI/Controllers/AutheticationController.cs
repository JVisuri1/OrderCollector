using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderCollectorAPI.Models;
using OrderCollectorAPI.Services;

namespace OrderCollectorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutheticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AutheticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] Login login)
        {
            return Ok(await _userService.Login(login));
        }
    }
}
