using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> RegisterCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(int customerId, Customer customer);
        Task<bool> RemoveCustomerAsync(int customerId);
    }
}
