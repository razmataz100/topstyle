using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Repository.Interfaces
{
    public interface IAdminRepo
    {
        Task<Admin> AuthenticateAdminAsync(string username, string password);
    }
}
