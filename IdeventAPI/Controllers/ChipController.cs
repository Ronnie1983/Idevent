﻿using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeventAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ChipController : ControllerBase
    {
        private ChipManager _chipManager = new ChipManager();

        private readonly ILogger<ChipController> _logger;

        public ChipController(ILogger<ChipController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(EventModel model)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            List<ChipModel> chips = _chipManager.GetAll();
            if(chips == null)
            {
                return StatusCode(500); // server error
            }
            if(chips.Count == 0)
            {
                return StatusCode(204, chips);
            }
            return Ok(chips);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ChipModel chip = _chipManager.GetById(id);
            if(chip == null)
            {
                return NotFound();
            }
            return Ok(chip);
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
