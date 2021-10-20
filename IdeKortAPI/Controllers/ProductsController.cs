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
    public class ProductsController : ControllerBase
    {
        private Manager<Product> mgrProduct = new Manager<Product>();
        private Manager<Active> mgrActive = new Manager<Active>();

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<Product>> GetAsync()
        {
            List<Product> result = await mgrProduct.GetItemsAsync();
            //result = await mgrProduct.ItemWithClasses(result);
            return result;
        }

        [HttpGet("chip/{id}")]
        public async Task<List<Product>> GetProductsByChip(int id)
        {
            List<Product> result = await mgrProduct.GetItemsAsync();
            //result = await mgrProduct.ItemWithClasses(result);
            return result;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            Product product = await mgrProduct.GetItemById(id);
            //product = await mgrProduct.ItemWithClasses(product);

            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<Product> Post([FromBody] Product value)
        {

            Product item = await mgrProduct.CreateItem(value);
            return item;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<Product> Put(int id, [FromBody] Product value)
        {
            if (value.ActiveClass != null)
            {
                Active active = await mgrActive.UpdateItemsById(value.ActiveClass);
            }

            Product item = await mgrProduct.UpdateItemsById(value);
            return item;
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            Product product = await mgrProduct.GetItemById(id);
            bool result = true;
            if (result)
            {
                result = await mgrProduct.DeleteItemsById(product.Id);
            }

            if (result)
            {
                result = await mgrActive.DeleteItemsById(product.Active);
            }

            return result;
        }
    }
}
