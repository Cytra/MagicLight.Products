using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicLight.Products.Model;
using MagicLight.Products.Data;

namespace MagicLight.Products.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Product.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Create()
        {
            var product = new Product() { Pavadinimas  = "test"};
            _context.Add(product);
            _context.SaveChangesAsync();
            return Ok(product);
        }
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
