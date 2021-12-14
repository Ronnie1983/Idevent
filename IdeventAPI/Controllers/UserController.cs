﻿using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult Get(string id)
        {
            var item = _userManager.GetByEmail(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
