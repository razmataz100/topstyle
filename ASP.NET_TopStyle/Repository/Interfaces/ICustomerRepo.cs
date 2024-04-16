using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Repository.Interfaces
{
    public interface ICustomerRepo
    {
        Task RegisterCustomerAsync(Customer customer);
        Task RemoveCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> GetCustomerByUsernameAsync(string username);
        Task<Customer> AuthenticateCustomerAsync(string username, string password);
    }
}
