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
    public class TransactionsController : ControllerBase
    {
        private Manager<Transaction> mgrTransaction = new Manager<Transaction>();

        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<List<Transaction>> GetAsync()
        {
            List<Transaction> transactions = await mgrTransaction.GetItemsAsync();
            //transactions = await mgrTransaction.ItemWithClasses(transactions);
            return transactions;
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<Transaction> Get(int id)
        {
            Transaction transaction = await mgrTransaction.GetItemById(id);
            //transaction = await mgrTransaction.ItemWithClasses(transaction);
            return transaction;
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public async Task<Transaction> Post([FromBody] Transaction value)
        {
            Transaction item = await mgrTransaction.CreateItem(value);
            return item;
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
