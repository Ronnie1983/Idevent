using Microsoft.AspNetCore.Mvc;
using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeventAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private StandProductManager _productManager = new StandProductManager();

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productManager.GetAll();
            if(products.Count == 0)
            {
                return Ok(new List<StandProductModel>());
            }
            return Ok(products);
        }

        [HttpGet("standid/{id}")]
        public IActionResult GetAllByStandId(int id)
        {
            var products = _productManager.GetAllByStandId(id);
            if (products.Count == 0)
            {
                //return StatusCode(204, new List<StandProductModel>());
                return Ok(new List<StandProductModel>());
            }
            return Ok(products);
        }
        [HttpGet("EventId/{id}")]
        public IActionResult GetAllByEventId(int id)
        {
            var products = _productManager.GetAllByEventId(id);
            if (products.Count == 0)
            {
                return Ok(new List<StandProductModel>());
            }
            return Ok(products);
        }
        // GET <ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productManager.GetById(id);
            if (product == null)
            {
                //return StatusCode(204, new List<StandProductModel>());
                return NoContent();
            }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<StandProductModel> Post([FromBody] StandProductModel item)
        {
            var result = _productManager.Create(item);
            return CreatedAtAction(nameof(GetById), new {id = result},item);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productManager.Delete(id);
            if(result == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
