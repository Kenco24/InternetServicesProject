using AutoMapper;
using InternetServicesProj.Data.Interfaces;
using InternetServicesProj.Data.Model;
using InternetServicesProj.Services.DTOs;
using InternetServicesProj.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InternetServicesProj.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            try
            {
                var categories = _categoryRepository.GetAll();
                return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all categories: {ex.Message}");
                throw; 
            }
        }

        public CategoryDTO GetCategoryById(int id)
        {
            try
            {
                var category = _categoryRepository.GetById(id);
                return _mapper.Map<CategoryDTO>(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting category by ID: {ex.Message}");
                throw;
            }
        }

        public CategoryDTO AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                _categoryRepository.Add(category);
                return _mapper.Map<CategoryDTO>(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
                throw;
            }
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                _categoryRepository.Update(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
                throw;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var category = _categoryRepository.GetById(id);
                _categoryRepository.Delete(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category: {ex.Message}");
                throw;
            }
        }
    }
}
