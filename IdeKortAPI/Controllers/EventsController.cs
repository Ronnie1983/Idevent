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
    public class EventsController : ControllerBase
    {
        private Manager<Event> mgrEvent = new Manager<Event>();

        private Manager<Address> mgrAddress = new Manager<Address>();
        private Manager<User> mgrUser = new Manager<User>();

        // GET: api/<EventsController>
        [HttpGet]
        public async Task<List<Event>> Get()
        {
            List<Event> Events = await mgrEvent.GetItemsAsync();
            //Events = await mgrEvent.ItemWithClasses(Events);
            return Events;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            Event result = await mgrEvent.GetItemById(id);
            //return await mgrEvent.ItemWithClasses(result);
            return result;
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<Event> Post([FromBody] Event value)
        {
            if (value.LocationClass != null)
            {
                Address address = await mgrAddress.CreateItem(value.LocationClass);
                value.Location = address.Id;
            }

            Event item = await mgrEvent.CreateItem(value);
            item.CompanyClass = await mgrUser.GetItemById(value.Company);
            item.LocationClass = await mgrAddress.GetItemById(value.Location);
            return item;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public async Task<Event> Put(int id, [FromBody] Event value)
        {
            if (value.LocationClass != null)
            {
                Address address = await mgrAddress.UpdateItemsById(value.LocationClass);
                value.Location = address.Id;
            }

            Event item = await mgrEvent.CreateItem(value);
            return item;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            Event item = await mgrEvent.GetItemById(id);
            bool result = true;
            if (result)
            {
                result = await mgrEvent.DeleteItemsById(item.Id);
            }

            if (result)
            {
                result = await mgrAddress.DeleteItemsById(item.Location);
            }

            
            return result;
        }
    }
}
