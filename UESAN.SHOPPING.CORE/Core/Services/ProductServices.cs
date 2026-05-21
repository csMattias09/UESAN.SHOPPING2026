using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var list = new List<ProductListDTO>();
            foreach (var p in products)
            {
                list.Add(new ProductListDTO
                {
                    Id = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock ?? 0,
                    Price = p.Price ?? 0,
                    Discount = p.Discount ?? 0,
                    CategoryId = p.CategoryId ?? 0
                });
            }
            return list;
        }

        public async Task<ProductListDTO> GetProduct(int id)
        {
            var p = await _productRepository.GetProductById(id);
            if (p == null) return null;
            return new ProductListDTO
            {
                Id = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Stock = p.Stock ?? 0,
                Price = p.Price ?? 0,
                Discount = p.Discount ?? 0,
                CategoryId = p.CategoryId ?? 0
            };
        }

        public async Task CreateProduct(ProductCreateDTO dto)
        {
            var product = new Product
            {
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock,
                Price = dto.Price,
                Discount = dto.Discount,
                CategoryId = dto.CategoryId,
                IsActive = true
            };
            await _productRepository.CreateProduct(product);
        }

        public async Task UpdateProduct(ProductUpdateDTO dto)
        {
            var product = new Product
            {
                Id = dto.Id,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock,
                Price = dto.Price,
                Discount = dto.Discount,
                CategoryId = dto.CategoryId
            };
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(ProductDeleteDTO dto)
        {
            await _productRepository.DeleteProduct(dto.Id);
        }
    }
}
