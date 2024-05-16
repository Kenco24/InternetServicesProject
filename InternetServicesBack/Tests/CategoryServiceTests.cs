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

    public class CategoryServiceTests
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        private Mock<ICategoryRepository> _categoryRepositoryMock = new Mock<ICategoryRepository>();
        private Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private CategoryService _categoryService;
        private List<Category> _categories;
        private List<CategoryDTO> _categoryDTOs;

        public CategoryServiceTests()
        {
            _categoryRepository = _categoryRepositoryMock.Object;
            _mapper = _mapperMock.Object;
            _categoryService = new CategoryService(_categoryRepository, _mapper);
            _categories = GetCategories();
            _categoryDTOs = GetCategoryDTOs();
        }

        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" }
            };
        }

        private List<CategoryDTO> GetCategoryDTOs()
        {
            return new List<CategoryDTO>
            {
                new CategoryDTO { Id = 1, Name = "Category 1" },
                new CategoryDTO { Id = 2, Name = "Category 2" }
            };
        }

        [Fact]
        public void GetAllCategories_ReturnsExpectedListOfCategories()
        {
            _categoryRepositoryMock.Setup(repo => repo.GetAll()).Returns(_categories);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CategoryDTO>>(_categories)).Returns(_categoryDTOs);

            var result = _categoryService.GetAllCategories();

            Assert.NotNull(result);
            Assert.Equal(_categoryDTOs.Count, result.Count());
        }

        [Fact]
        public void GetCategoryById_WithValidId_ReturnsExpectedCategory()
        {
            int categoryId = 1;
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            var categoryDTO = _categoryDTOs.FirstOrDefault(c => c.Id == categoryId);
            _categoryRepositoryMock.Setup(repo => repo.GetById(categoryId)).Returns(category);
            _mapperMock.Setup(mapper => mapper.Map<CategoryDTO>(category)).Returns(categoryDTO);

            var result = _categoryService.GetCategoryById(categoryId);

            Assert.NotNull(result);
            Assert.Equal(categoryId, result.Id);
        }
    }
}
