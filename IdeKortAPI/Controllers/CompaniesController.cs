using IdeKortAPI.Manager;
using IdeKortLib.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeKortAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        Manager<Company> mgr = new Manager<Company>();


        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<List<Company>> GetAsync()
        {
            List<Company> List = await mgr.GetItemsAsync();
            return List;
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<Company> Get(int id)
        {

            Company item = await mgr.GetItemById(id);

            return item;
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<Company> Post([FromBody] Company value)
        {
            return await mgr.CreateItem(value);
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
