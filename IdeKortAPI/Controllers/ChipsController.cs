using Microsoft.AspNetCore.Mvc;
using IdeKortAPI.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdeKortLib.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeKortAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipsController : ControllerBase
    {
        private Manager<Chip> mgrChip = new Manager<Chip>();
        private Manager<Active> mgrActive = new Manager<Active>();
        private Manager<Event> mgrEvent = new Manager<Event>();
        private Manager<User> mgrUser = new Manager<User>();

        private UsersController userController = new UsersController();
        private ActivesController activeController = new ActivesController();
        private EventsController eventsController = new EventsController();

        // GET: api/<ChipsController>
        [HttpGet]
        public async Task<List<Chip>> GetAsync()
        {
            List<Chip> chips = await mgrChip.GetItemsAsync();
            //chips = await mgrChip.ItemWithClasses(chips);
            return chips;
        }

        // GET api/<ChipsController>/5
        [HttpGet("{id}")]
        public async Task<Chip> Get(int id)
        {
            Chip result = await mgrChip.GetItemById(id);
            //result = await mgrChip.ItemWithClasses(result);
            
            result.CompanyClass = await userController.Get(result.Company);
            result.UserClass = await userController.Get(result.User);
            result.ActiveClass = await activeController.Get(result.Active);
            result.EventClass = await eventsController.Get(result.Event);

            return result;
        }

        // POST api/<ChipsController>
        [HttpPost]
        public async Task<Chip> Post([FromBody] Chip value)
        {
            return await mgrChip.CreateItem(value);
        }

        // PUT api/<ChipsController>/5
        [HttpPut("{id}")]
        public async Task<Chip> Put(int id, [FromBody] Chip value)
        {
            if (value.CompanyClass != null)
            {
                User companyClass = await mgrUser.UpdateItemsById(value.CompanyClass);
                value.Company = companyClass.Id;
            }

            if (value.ActiveClass != null)
            {
                Active active = await mgrActive.UpdateItemsById(value.ActiveClass);
                value.Active = active.Id;
            }

            if (value.EventClass != null)
            {
                Event eventc = await mgrEvent.UpdateItemsById(value.EventClass);
                value.Event = eventc.Id;
            }

            if (value.UserClass != null)
            {
                User user = await mgrUser.UpdateItemsById(value.UserClass);
                value.User = user.Id;
            }

            Chip chip = await mgrChip.UpdateItemsById(value);
            
            return chip;
        }

        // DELETE api/<ChipsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            Chip chip = await mgrChip.GetItemById(id);
            bool result = true;
            if (result)
            {
                result = await mgrChip.DeleteItemsById(chip.Id);
            }

            if (result)
            {
                result = await mgrActive.DeleteItemsById(chip.Active);
            }

            return result;
        }
    }
}
