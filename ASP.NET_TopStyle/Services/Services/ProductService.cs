using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Repository.Interfaces;
using ASP.NET_TopStyle.Services.Interfaces;

public class ProductService : IProductService
{
    private readonly IProductRepo _productRepo;

    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<List<ShowSingleProductDTO>> SearchProductsAsync(string searchTerm)
    {
        var products = await _productRepo.SearchProductsAsync(searchTerm);
        return products.Select(p => new ShowSingleProductDTO
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryName = p.Category?.CategoryName,
            CategoryId = p.Category.CategoryId
        }).ToList();
    }
}