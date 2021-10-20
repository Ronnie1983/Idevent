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
    public class AmountsController : ControllerBase
    {
        private Manager<Amount> mgrAmount = new Manager<Amount>();
        private Manager<Chip> mgrChip = new Manager<Chip>();
        private Manager<Product> mgrProduct = new Manager<Product>();

        // GET: api/<AmountsController>
        [HttpGet]
        public async Task<List<Amount>> GetAsync()
        {
            List<Amount> amounts = await mgrAmount.GetItemsAsync();
            foreach (Amount amount in amounts)
            {
                amount.ChipClass = await mgrChip.GetItemById(amount.Chip);
                amount.ProductClass = await mgrProduct.GetItemById(amount.Product);
            }
            return amounts;
        }

        [HttpGet("chip/{id}")]
        public async Task<List<Amount>> GetItemForChip(int id)
        {
            List<Amount> amounts = await mgrAmount.GetItemsAsync();
            foreach (Amount amount in amounts)
            {
                amount.ChipClass = await mgrChip.GetItemById(amount.Chip);
                amount.ProductClass = await mgrProduct.GetItemById(amount.Product);
            }

            List<Amount> result = amounts.Where(o => o.Chip == id).ToList();

            return result;
        }

        // GET api/<AmountsController>/5
        [HttpGet("{id}")]
        public async Task<Amount> Get(int id)
        {
            Amount amount = await mgrAmount.GetItemById(id);
            amount.ChipClass = await mgrChip.GetItemById(amount.Chip);
            amount.ProductClass = await mgrProduct.GetItemById(amount.Product);
            return amount;
        }

        // GET api/<AmountsController>/5
        [HttpGet("decrease/{id}/{amounts}")]
        public async Task<Amount> DecreaseByAmount(int id, int amounts)
        {
            Amount amount = await mgrAmount.GetItemById(id);
            
            amount.ChipClass = await mgrChip.GetItemById(amount.Chip);
            amount.ProductClass = await mgrProduct.GetItemById(amount.Product);
            if (amount.Total > 0)
            {
                amount.Total = amount.Total - amounts;
                await mgrAmount.UpdateItemsById(amount);
            }
            
            return amount;
        }

        // POST api/<AmountsController>
        [HttpPost]
        public async Task<Amount> Post([FromBody] Amount value)
        {
            Amount item = await mgrAmount.CreateItem(value);
            item.ChipClass = await mgrChip.GetItemById(value.Chip);
            item.ProductClass = await mgrProduct.GetItemById(value.Product);
            return item;
        }

        // PUT api/<AmountsController>/5
        [HttpPut("{id}")]
        public async Task<Amount> Put(int id,[FromBody] Amount value)
        {
            if (value.ChipClass != null)
            {
                Chip chip = await mgrChip.UpdateItemsById(value.ChipClass);
                value.Chip = chip.Id;
            }

            if (value.ProductClass != null)
            {
                Product product = await mgrProduct.UpdateItemsById(value.ProductClass);
                value.Product = product.Id;
            }

            Amount item = await mgrAmount.UpdateItemsById(value);
            return item;
        }

        // DELETE api/<AmountsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            Amount amount = await mgrAmount.GetItemById(id);
            bool result = true;
            if (result)
            {
                result = await mgrAmount.DeleteItemsById(amount.Id);
            }

            return result;
        }
    }
}
