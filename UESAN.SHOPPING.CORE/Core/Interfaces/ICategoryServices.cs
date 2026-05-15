using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryServices
    {
        Task CreateCategory(CategoryCreateDTO categoryCreateDto);
        Task DeleteCategory(CategoryDeleteDTO categoryDeleteDto);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategory(int id);
        Task UpdateCategory(CategoryUpdateDTO categoryUpdateDto);
    }
}