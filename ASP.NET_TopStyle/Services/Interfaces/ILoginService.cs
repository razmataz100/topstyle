using ASP.NET_TopStyle.Models.DTOs;

namespace ASP.NET_TopStyle.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginDTO loginDTO);
    }
}
