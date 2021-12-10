using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IdeventAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ChipGroupController : ControllerBase
    {
        private ChipGroupManager _groupManager = new();

        [HttpPost]
        public ActionResult Create([FromBody] ChipGroupModel newChipGroup)
        {
            int newGroupId = _groupManager.Create(newChipGroup);
            if (newGroupId > 0)
            {
                return CreatedAtAction(nameof(GetById), new { id = newGroupId }, newChipGroup);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }
        [HttpGet("EventId/{eventId}")]
        public IActionResult GetAllByEventId(int eventId)
        {
            List<ChipGroupModel> chipGroups = _groupManager.GetAllByEventId(eventId);

            return Ok(chipGroups);
        }
        [HttpGet("{chipGroupId}")]
        public IActionResult GetById(int chipGroupId)
        {
            throw new NotImplementedException();
        }
    }
}
