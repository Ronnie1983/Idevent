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
        public IActionResult Create(EventModel model)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var events = _eventManager.GetAll();
            
            if (events.Count == 0)
            {
                return Ok(new List<EventModel>());
            }
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var eventModel = _eventManager.GetById(id);
                if(eventModel == null)
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
