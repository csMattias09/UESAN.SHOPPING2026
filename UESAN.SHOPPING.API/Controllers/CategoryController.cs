using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryServices.GetCategories();
            return Ok(categories);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO categoryCreateDto)
        {
            await _categoryServices.CreateCategory(categoryCreateDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO categoryUpdateDto)
        {
            await _categoryServices.UpdateCategory(categoryUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryServices.DeleteCategory(new CategoryDeleteDTO { Id = id });
            return Ok();
        }


    }
}
