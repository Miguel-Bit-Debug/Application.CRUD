using Domain.Interfaces;
using Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.API.Controllers.Product
{
    [Route("/v1/api")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return BadRequest(product);

            return Ok(product);
        }

        [HttpPost("/")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            await _productService.AddProduct(product);
            return Ok(product);
        }

        [HttpDelete("/")]
        public async Task<IActionResult> DeleleProduct([FromBody] int id)
        {
            if(!ModelState.IsValid) return BadRequest("Id is required");

            var successDeleted = await _productService.DeleteProduct(id);
            if (!successDeleted)
                return BadRequest("Product not found");
            return Ok("Product deleted.");
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var productUpdated = await _productService.UpdateProduct(id, product);
            if (productUpdated == false)
                return BadRequest("Product not found");
            return Ok("Product Updated.");
        }
    }
}
