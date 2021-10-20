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
    public class UsersController : ControllerBase
    {
        private Manager<User> mgrUser = new Manager<User>();

        private Manager<Address> mgrAddress = new Manager<Address>();
        private Manager<Active> mgrActive = new Manager<Active>();
        private Manager<Customer> mgrCustomer = new Manager<Customer>();
        private Manager<Company> mgrCompany = new Manager<Company>();

        private CompaniesController companiesController = new CompaniesController();
        private ActivesController activeController = new ActivesController();
        private AddressesController addressesController = new AddressesController();
        private CustomersController customersController = new CustomersController();
        private RolesController rolesController = new RolesController();

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            List<User> Users = await mgrUser.GetItemsAsync();
            return Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            User result = await mgrUser.GetItemById(id);
            result.CompanyClass = await companiesController.Get(result.Company);
            result.ActiveClass = await activeController.Get(result.Active);
            result.AddressClass = await addressesController.Get(result.Address);
            result.CustomerClass = await customersController.Get(result.Customer);
            result.RoleClass = await rolesController.Get(result.Role);

            return result;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<User> Post([FromBody] User value)
        {
            if (value.AddressClass != null)
            {
                Address address = await mgrAddress.CreateItem(value.AddressClass);
                value.Address = address.Id;
            }

            if (value.CustomerClass != null)
            {
                Customer customer = await mgrCustomer.CreateItem(value.CustomerClass);
                value.Customer = customer.Id;
            }

            if (value.CompanyClass != null)
            {
                Company company = await mgrCompany.CreateItem(value.CompanyClass);
                value.Company = company.Id;
            }

            if (value.ActiveClass != null)
            {
                Active active = await mgrActive.CreateItem(value.ActiveClass);
                value.Active = active.Id;
            }
            User item = await mgrUser.CreateItem(value);

            return item;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] User value)
        {
            if (value.AddressClass != null)
            {
                Address address = await mgrAddress.UpdateItemsById(value.AddressClass);
                value.Address = address.Id;
            }

            if (value.CustomerClass != null)
            {
                Customer customer = await mgrCustomer.UpdateItemsById(value.CustomerClass);
                value.Customer = customer.Id;
            }

            if (value.CompanyClass != null)
            {
                Company company = await mgrCompany.UpdateItemsById(value.CompanyClass);
                value.Company = company.Id;
            }

            if (value.ActiveClass != null)
            {
                Active active = await mgrActive.UpdateItemsById(value.ActiveClass);
                value.Active = active.Id;
            }
            User item = await mgrUser.UpdateItemsById(value);

            return item;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            User user = await mgrUser.GetItemById(id);
            bool result = true;
            if (result)
            {
                result = await mgrUser.DeleteItemsById(user.Id);
            }
            if (result)
            {
                result = await mgrAddress.DeleteItemsById(user.Address);
            }

            if (result)
            {
                result = await mgrActive.DeleteItemsById(user.Active);
            }
            if (user.Company != 0 && result)
            {
                result = await mgrCustomer.DeleteItemsById(user.Customer);
            }

            if (user.Customer != 0 && result)
            {
                result = await mgrCompany.DeleteItemsById(user.Company);
            }

            return result;
        }
    }
}
