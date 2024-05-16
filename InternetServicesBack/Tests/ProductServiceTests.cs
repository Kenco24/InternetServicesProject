using AutoMapper;
using Moq;
using InternetServicesProj.Data.Interfaces;
using InternetServicesProj.Data.Model;
using InternetServicesProj.Services.DTOs;
using InternetServicesProj.Services.Interfaces;
using InternetServicesProj.Services.Services;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace InternetServicesProj.Tests.UnitTests.Services
{
    public class ProductServiceTests
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        private Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private ProductService _productService;
        private List<Product> _products;
        private List<ProductDTO> _productDTOs;

        public ProductServiceTests()
        {
            _productRepository = _productRepositoryMock.Object;
            _mapper = _mapperMock.Object;
            _productService = new ProductService(_productRepository, _mapper);
            _products = GetProducts();
            _productDTOs = GetProductDTOs();
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0M },
                new Product { Id = 2, Name = "Product 2", Price = 20.0M }
            };
        }

        private List<ProductDTO> GetProductDTOs()
        {
            return new List<ProductDTO>
            {
                new ProductDTO { Id = 1, Name = "Product 1", Price = 10.0M },
                new ProductDTO { Id = 2, Name = "Product 2", Price = 20.0M }
            };
        }

        [Fact]
        public void GetAllProducts_ReturnsExpectedListOfProducts()
        {
            _productRepositoryMock.Setup(repo => repo.GetAll()).Returns(_products);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProductDTO>>(_products)).Returns(_productDTOs);

            var result = _productService.GetAllProducts();

            Assert.NotNull(result);
            Assert.Equal(_productDTOs.Count, result.Count());

        }

        [Fact]
        public void GetProductById_WithValidId_ReturnsExpectedProduct()
        {
            int productId = 1;
            var product = _products.FirstOrDefault(p => p.Id == productId);
            var productDTO = _productDTOs.FirstOrDefault(p => p.Id == productId);
            _productRepositoryMock.Setup(repo => repo.GetById(productId)).Returns(product);
            _mapperMock.Setup(mapper => mapper.Map<ProductDTO>(product)).Returns(productDTO);

             
            var result = _productService.GetProductById(productId);

            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);

        }

    }
}
