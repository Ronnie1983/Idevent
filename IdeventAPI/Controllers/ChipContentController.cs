using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ChipContentController : ControllerBase
    {
        private ChipContentManager _chipContentManager = new ChipContentManager();
        // GET: <ChipContentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET content from chip <ChipContentController>/5
        [HttpGet("chipcontent/{id}")]
        public IActionResult GetByChipId(int id)
        {
            var products = _chipContentManager.GetAllByChipId(id);
            if (products.Count == 0)
            {
                //return StatusCode(204, new List<StandProductModel>());
                return Ok(new List<StandProductModel>());
            }
            return Ok(products);
        }


        // GET content from chip <ChipContentController>/5
        [HttpGet("{chipId}/{standId}")]
        public IActionResult GetByChipId(int chipId, int standId)
        {
            var products = _chipContentManager.GetAllByChipAndStandId(chipId, standId);
            if (products.Count == 0)
            {
                //return StatusCode(204, new List<StandProductModel>());
                return Ok(new List<StandProductModel>());
            }
            return Ok(products);
        }

        

        [HttpPost("Multiple")]
        public IActionResult CreateMultiple([FromBody] List<ChipContentModel> contentsToBeCreated)

        {
            bool success = _chipContentManager.CreateMultiple(contentsToBeCreated);
            if(success) return Ok(success);

            return BadRequest(contentsToBeCreated);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
