using InternetServicesProj.Services.DTOs;

namespace InternetServicesProj.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
        CategoryDTO AddCategory(CategoryDTO categoryDTO);
        void UpdateCategory(CategoryDTO categoryDTO);
        void DeleteCategory(int id);
    }
}
