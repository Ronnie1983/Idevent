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
        // GET: api/<ChipContentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ChipContentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET content from chip api/<ChipContentController>/5
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

        // POST api/<ChipContentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChipContentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChipContentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
