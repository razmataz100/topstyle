using ASP.NET_TopStyle.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<IActionResult> SearchProducts(string searchTerm)
    {
        var products = await _productService.SearchProductsAsync(searchTerm);
        if (!products.Any())
        {
            return NotFound("No products found with the given search criteria.");
        }
            
        return Ok(products);
    }
}
