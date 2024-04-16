using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Data.Contexts;
using ASP.NET_TopStyle.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_TopStyle.Repository.repo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task RegisterCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<Customer> GetCustomerByUsernameAsync(string username)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task<Customer> AuthenticateCustomerAsync(string username, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
