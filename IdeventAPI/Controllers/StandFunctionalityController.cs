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
    public class StandFunctionalityController : ControllerBase
    {
        private StandFunctionalityManager _functionalityManager = new StandFunctionalityManager();

        private readonly ILogger<StandFunctionalityController> _logger;

        public StandFunctionalityController(ILogger<StandFunctionalityController> logger)
        {
            _logger = logger;
        }

        // GET: api/<StandFunctionalityController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var functions = _functionalityManager.GetAll();
            if(functions.Count == 0)
            {
                return Ok(new List<StandFunctionalityModel>());
            }
            return Ok(functions);
        }

        // GET api/<StandFunctionalityController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            StandFunctionalityModel model = _functionalityManager.GetById(id);
            return Ok(model);
        }

        // POST <StandFunctionalityController>
        [HttpPost]
        public ActionResult Create([FromBody] StandFunctionalityModel newFunctionality)
        {
            int createdId = _functionalityManager.Create(newFunctionality);
            if(createdId == 0)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new {id = createdId}, newFunctionality);
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
