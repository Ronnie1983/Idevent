using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                return Ok(new List<EventStandModel>());
            }
            return Ok(stands);
        }

        [HttpGet("ByEvent/{id}")]
        public IActionResult GetAllByEventId(int id)
        {
            var stands = _eventStandManager.GetAllByEventId(id);
            if (stands.Count == 0)
            {
                return Ok(new List<EventStandModel>());
            }
            return Ok(stands);
        }

        // GET api/<StandController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var stands = _eventStandManager.GetById(id);
            if (stands == null)
            {
                return NoContent();
            }
            return Ok(stands);
        }

        // POST api/<StandController>
        [HttpPost]
        public ActionResult<EventStandModel> Post([FromBody] EventStandModel item)
        {
            var result = _eventStandManager.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = result }, item);
        }

        // PUT api/<StandController>/5
        [HttpPut("UpdateName/{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            var result = _eventStandManager.Update(id, value);
            if(result == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DELETE api/<StandController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _eventStandManager.Delete(id);
            if(result == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
