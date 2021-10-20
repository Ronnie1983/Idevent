using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeKortAPI.Manager;
using IdeKortLib.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeKortAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivesController : ControllerBase
    {
        private Manager<Active> mgrActive = new Manager<Active>();

        // GET: api/<ActivesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ActivesController>/5
        [HttpGet("{id}")]
        public async Task<Active> Get(int id)
        {
            Active active = await mgrActive.GetItemById(id);
            return active;
        }

        // POST api/<ActivesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActivesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActivesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
