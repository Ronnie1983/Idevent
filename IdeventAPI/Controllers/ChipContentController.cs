using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using System.Collections.Generic;

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

        // POST <ChipContentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <ChipContentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <ChipContentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
