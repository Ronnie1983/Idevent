using System.Collections.Generic;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager _userManager = new UserManager();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetByEmail(string email)
        {
            var item = _userManager.GetByEmail(email);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
