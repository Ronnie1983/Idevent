using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class StandFunctionalityController : ControllerBase
    {
        private StandFunctionalityManager _manager = new StandFunctionalityManager();

        private readonly ILogger<StandFunctionalityController> _logger;

        public StandFunctionalityController(ILogger<StandFunctionalityController> logger)
        {
            _logger = logger;
        }

        // GET: api/<StandFunctionalityController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var functions = _manager.GetAll();
            if(functions.Count == 0)
            {
                return NoContent();
            }
            return Ok(functions);
        }

        // GET api/<StandFunctionalityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StandFunctionalityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StandFunctionalityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StandFunctionalityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
