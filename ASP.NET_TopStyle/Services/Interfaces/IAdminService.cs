using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> AddProductAsync(ProductAddDTO productAddDto);
    }
}
