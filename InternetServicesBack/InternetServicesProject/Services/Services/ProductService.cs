using AutoMapper;
using InternetServicesProj.Data.Interfaces;
using InternetServicesProj.Data.Model;
using InternetServicesProj.Services.DTOs;
using InternetServicesProj.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InternetServicesProj.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                return _mapper.Map<IEnumerable<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all products: {ex.Message}");
                throw;
            }
        }

        public ProductDTO GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting product by ID: {ex.Message}");
                throw;
            }
        }

        public ProductDTO AddProduct(ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productDTO);
                _productRepository.Add(product);
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                throw;
            }
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productDTO);
                _productRepository.Update(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                _productRepository.Delete(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                throw;
            }
        }
        public void RestockProduct(int productId, int quantityToAdd)
        {
            try
            {
                var product = _productRepository.GetById(productId);
                if (product != null)
                {
                    product.Quantity += quantityToAdd;
                    _productRepository.Update(product);
                }
                else
                {
                    throw new ArgumentException($"Product with ID {productId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error restocking product: {ex.Message}");
                throw;
            }
        }
    }
}
