using System.Collections.Generic;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("CustomData")]
        public IActionResult GetAllCustomData()
        {
            Dictionary<string, UserModel> users = _userManager.GetAllCustomData();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("Email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var item = _userManager.GetByEmail(email);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var item = _userManager.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            bool result = _userManager.DeleteById(id);
            if (result)
            {
                return Ok();
            } else { return BadRequest(); }
        }


    }
}
