using InternetServicesProj.Services.DTOs;
using InternetServicesProj.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InternetServicesProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        public PurchaseController(IProductService productService, IDiscountService discountService)
        {
            _productService = productService;
            _discountService = discountService;
        }

        [HttpPost]
        public IActionResult PurchaseProducts([FromBody] List<int> productIds)
        {
            var purchasedProducts = new List<ProductDTO>();
            var totalPrice = 0m;

            foreach (var productId in productIds)
            {
                var product = _productService.GetProductById(productId);
                if (product == null || product.Quantity < 1)
                {
                    return BadRequest($"Product with ID {productId} is not available or has insufficient quantity.");
                }
                purchasedProducts.Add(product);
                totalPrice += product.Price;
            }

            decimal discount = 0m;
            if (purchasedProducts.Count > 1)
            {
                var purchasedProductIds = purchasedProducts.Select(p => p.Id);
                discount = _discountService.CalculateDiscount(purchasedProductIds);
            }

            totalPrice -= discount;

            foreach (var product in purchasedProducts)
            {
                product.Quantity -= 1;
                _productService.UpdateProduct(product);
            }

           

            var response = new
            {
                TotalPrice = "$" +totalPrice +" total price after discount",
                DiscountApplied = "$"+ discount + " discount applied ",
                PurchasedProducts = purchasedProducts.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price
                }),
            };

            return Ok(response);
        }
    }
}
