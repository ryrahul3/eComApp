using System;
using System.Security.Claims;
using System.Threading.Tasks;
using eComApp.API.Data;
using eComApp.API.Helpers;
using eComApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eComApp.API.Controllers
{
    [Produces("application/json")] 
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IEComRepository _repo;
        public ProductController(IEComRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]ProductParams productParams)
        {
            var products = await _repo.GetProducts(productParams);
            return Ok(products);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (int.Parse(User.FindFirst(ClaimTypes.Role).Value) != 1)
                return Unauthorized();

            product.CreatedBy = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            if (await _repo.UpdateProduct(product))
                return NoContent();

            throw new Exception($"Updating product {product.Name} failed ");
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(Product product)
        {
            if (int.Parse(User.FindFirst(ClaimTypes.Role).Value) != 1)
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest();
            
            product.CreatedBy = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            var addedProduct = await _repo.SaveProduct(product);
            return Ok(addedProduct);
        }
    }
}