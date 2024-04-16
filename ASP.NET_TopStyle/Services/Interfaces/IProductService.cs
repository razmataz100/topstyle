using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product product);
    }
}
