using Microsoft.EntityFrameworkCore;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Data;

namespace UESAN.SHOPPING.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existing = await _context.Product.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
            if (existing != null)
            {
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl;
                existing.Stock = product.Stock;
                existing.Price = product.Price;
                existing.Discount = product.Discount;
                existing.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var existing = await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (existing != null)
            {
                existing.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
