using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private AddressManager _addressManager = new AddressManager();

        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var address = _addressManager.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        // POST api/<AddressController>
        [HttpPost]
        public ActionResult<AddressModel> Post([FromBody] AddressModel value)
        {
            var result = _addressManager.Create(value);
            return CreatedAtAction(nameof(GetById), new { id = result }, value);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AddressModel value)
        {
            var result = _addressManager.UpdateAddress(value);
            if(result == 1)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
