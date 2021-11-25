using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private CompanyManager _companyManager = new CompanyManager();

        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _companyManager.GetAll();
            if(companies.Count == 0)
            {
                return Ok(new List<CompanyModel>());
            }
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _companyManager.GetById(id);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public ActionResult<CompanyModel> Post([FromBody] CompanyModel value)
        {
            var result = _companyManager.Create(value);
            return CreatedAtAction(nameof(GetById), new { id = result }, value);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
