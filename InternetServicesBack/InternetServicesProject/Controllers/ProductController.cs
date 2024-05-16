using InternetServicesProj.Services.Interfaces;
using InternetServicesProj.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InternetServicesProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ProductDTO> Get(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDTO> Post([FromBody] ProductDTO productDTO)
        {
            var createdProduct = _productService.AddProduct(productDTO);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductDTO productDTO)
        {
            _productService.UpdateProduct(productDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }


        [HttpPost("restock/{productId}")]
        public IActionResult RestockProduct(int productId, [FromBody] int quantityToAdd)
        {
            try
            {
                _productService.RestockProduct(productId, quantityToAdd);
                return Ok($"Product with ID {productId} successfully restocked with {quantityToAdd} units.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
