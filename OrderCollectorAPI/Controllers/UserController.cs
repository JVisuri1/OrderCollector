using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderCollectorAPI.Data;
using OrderCollectorAPI.Models;
using OrderCollectorAPI.Services;

namespace OrderCollectorAPI.Controllers
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

        [HttpGet]
        [Route("getcurrentuser")]
        public async Task<User> GetCurrentUser()
        {
            return await _userService.GetCurrentUser();
        }

        [HttpPost]
        [Route("register")]
        public async Task<bool> CreateNewUser(Login login)
        {
            return await _userService.CreateNewUser(login);
        }
    }
}
