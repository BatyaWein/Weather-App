using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeatherProjectAPI.BL;
using WeatherProjectAPI.DTO;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class LoginBody
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        private readonly ILogger<UserController> _logger;
        private IUserBL _userBL;

        public UserController(IUserBL userBL, ILogger<UserController> logger)
        {
            _userBL = userBL;
            _logger = logger;
        }

        [Route("signUp")]
        [HttpPost]
        public Task<DTO_User> createUser([FromBody] DTO_User user)
        {
            return _userBL.createUser(user);
        }

        [Route("login")]
        [HttpPost]
        public async Task<DTO_User> LoginUser([FromBody] LoginBody body)
        {
            DTO_User user = await _userBL.GetUser(body.email, body.password);
            return user;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<DTO_User> GetUserById(Guid id)
        {
            return await _userBL.GetUserById(id);
        }
    }
}
