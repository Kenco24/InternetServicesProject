using InternetServicesProj.Services.Interfaces;
using InternetServicesProj.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InternetServicesProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<CategoryDTO> Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<CategoryDTO> Post([FromBody] CategoryDTO categoryDTO)
        {
            var createdCategory = _categoryService.AddCategory(categoryDTO);
            return CreatedAtAction(nameof(Get), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CategoryDTO categoryDTO)
        {
            _categoryService.UpdateCategory(categoryDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
