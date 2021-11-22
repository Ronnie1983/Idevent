using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class StandController : ControllerBase
    {
        private EventStandManager _eventStandManager = new EventStandManager();

        private readonly ILogger<StandController> _logger;

        public StandController(ILogger<StandController> logger)
        {
            _logger = logger;
        }
        // GET: api/<StandController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var stands = _eventStandManager.GetAll();
            if (stands.Count == 0)
            {
                return NoContent();
            }
            return Ok(stands);
        }

        // GET api/<StandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StandController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
