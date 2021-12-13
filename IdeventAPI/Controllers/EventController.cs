using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeventAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class EventController : ControllerBase
    {
        private EventManager _eventManager;

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
            _eventManager = new EventManager();
        }

        [HttpPost]
        public ActionResult Create(EventModel model) // Maybe only works with ActionResult (not IActionResult)
        {
            int createdId = _eventManager.Create(model);
            if (createdId > 0)
            {
                return CreatedAtAction(nameof(GetById), new { Id = createdId }, model); // Id = createdId might cause issue?
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<EventModel> events = _eventManager.GetAll();

            if (events.Count == 0)
            {
                return Ok(new List<EventModel>());
            }
            return Ok(events);
        }
        [HttpGet("CompanyId/{companyId}")]
        public IActionResult GetAllByCompanyId(int companyId)
        {
            List<EventModel> events = _eventManager.GetAllByCompanyId(companyId);

            if (events.Count == 0)
            {
                return Ok(new List<EventModel>());
            }
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EventModel eventModel = _eventManager.GetById(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel);
        }

        [HttpPut]
        public IActionResult Update(int oldModelId, EventModel newModel)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
