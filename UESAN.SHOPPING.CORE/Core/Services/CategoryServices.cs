using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoryDtos = new List<CategoryListDTO>();

            foreach (var category in categories)
            {
                categoryDtos.Add(new CategoryListDTO
                {
                    Id = category.Id,
                    Description = category.Description
                });
            }

            return categoryDtos;
        }

        public async Task<CategoryListDTO> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            var categoryDto = new CategoryListDTO
            {
                Id = category.Id,
                Description = category.Description
            };
            return categoryDto;

        }
        public async Task CreateCategory(CategoryCreateDTO categoryCreateDto)
        {
            var category = new Category
            {
                Description = categoryCreateDto.Description,
                IsActive = true
            };
            await _categoryRepository.CreateCategory(category);
        }

        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDto)
        {
            var category = new Category
            {
                Id = categoryUpdateDto.Id,
                Description = categoryUpdateDto.Description
            };
            await _categoryRepository.UpdateCategory(category);
        }
        public async Task DeleteCategory(CategoryDeleteDTO categoryDeleteDto)
        {
            await _categoryRepository.DeleteCategory(categoryDeleteDto.Id);
        }


    }
}
