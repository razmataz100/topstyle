using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Repository.Interfaces
{
    public interface IProductRepo
    {
        Task AddProductAsync(Product product);
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<List<Product>> SearchProductsAsync(string searchTerm);
    }
}
