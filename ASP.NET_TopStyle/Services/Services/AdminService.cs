using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Interfaces;
using ASP.NET_TopStyle.Repository.repo;
using ASP.NET_TopStyle.Services.Interfaces;

namespace ASP.NET_TopStyle.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IProductRepo _productRepo;

        public AdminService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<bool> AddProductAsync(ProductAddDTO productAddDto)
        {
            var category = await _productRepo.GetCategoryByIdAsync(productAddDto.CategoryId);

            if (category == null)
            {
                return false;
            }

            var product = new Product
            {
                Name = productAddDto.Name,
                Description = productAddDto.Description,
                Price = productAddDto.Price,
                Category = category

            };
            try
            {
                await _productRepo.AddProductAsync(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
