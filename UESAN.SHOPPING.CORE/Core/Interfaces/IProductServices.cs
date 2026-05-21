using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IProductServices
    {
        Task CreateProduct(ProductCreateDTO dto);
        Task DeleteProduct(ProductDeleteDTO dto);
        Task<IEnumerable<ProductListDTO>> GetProducts();
        Task<ProductListDTO> GetProduct(int id);
        Task UpdateProduct(ProductUpdateDTO dto);
    }
}
