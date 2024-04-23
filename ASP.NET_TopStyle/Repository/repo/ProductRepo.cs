using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Data.Contexts;
using ASP.NET_TopStyle.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_TopStyle.Repository.repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<List<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Where(p => p.Name.Contains(searchTerm) ||
                                             p.Description.Contains(searchTerm) ||
                                             p.Category.CategoryName.Contains(searchTerm))
                                 .ToListAsync();
        }
    }
}

