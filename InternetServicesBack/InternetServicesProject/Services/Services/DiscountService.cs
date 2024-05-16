using InternetServicesProj.Data.Interfaces;
using InternetServicesProj.Data.Model;
using InternetServicesProj.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InternetServicesProj.Services.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IProductRepository _productRepository;

        public DiscountService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public decimal CalculateDiscount(IEnumerable<int> productIds)
        {
            try
            {
                var products = new List<Product>();

                foreach (var id in productIds)
                {
                    var product = _productRepository.GetById(id);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                    else
                    {
                        return 0;
                    }
                }

                decimal totalPrice = 0;
                decimal discountedPrice = 0;
                var discountedCategories = new HashSet<int>();

                foreach (var product in products)
                {
                    totalPrice += product.Price;

                    if (!discountedCategories.Contains(product.CategoryIds.First()))
                    {
                        discountedCategories.Add(product.CategoryIds.First());
                        discountedPrice += product.Price * 0.05m;
                    }
                }

                return discountedPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating discount: {ex.Message}");
                throw;
            }
        }
    }
}
