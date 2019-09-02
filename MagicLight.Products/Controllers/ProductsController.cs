using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicLight.Products.Model;
using MagicLight.Products.Data;
using Microsoft.AspNetCore.Http;

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

        [HttpGet("{id:int}/GetByInternalId", Name = "GetByInternalId")]
        public IActionResult GetByInternalId(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}/GetByExternalId", Name = "GetByExternalId")]
        public IActionResult GetByExternalId(string id)
        {
            var product = _context.Product.Where(x => x.ProductNumber == id).ToList();
            if (!product.Any())
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_context.Product.ToList());
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateAsync([FromBody]Product product)
        {
            //TODO add validations
            if (string.IsNullOrEmpty(product.ProductNumber))
            {
                return BadRequest();
            }

            await _context.Product.AddAsync(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetByInternalId", new { id = product.Id }, product);
        }

        [HttpPut("{id}/Update")]
        public IActionResult Update(int id, Product product)
        {
            var existingProduct = _context.Product.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Category = product.Category;
            existingProduct.SubCategory = product.SubCategory;
            existingProduct.SubSubCategoryName = product.SubSubCategoryName;
            existingProduct.Url = product.Url;
            existingProduct.ProductImageLink = product.ProductImageLink;
            existingProduct.Description = product.Description;
            existingProduct.ProductNumber = product.ProductNumber;
            existingProduct.Pavadinimas = product.Pavadinimas;
            existingProduct.Apibudinimas = product.Apibudinimas;
            existingProduct.Price = product.Price;
            _context.Product.Update(existingProduct);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
