using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Interfaces;
using ASP.NET_TopStyle.Services.Interfaces;

namespace ASP.NET_TopStyle.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


        public async Task<bool> RegisterCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepo.GetCustomerByUsernameAsync(customer.Username);
            if (existingCustomer != null)
            {
                return false;
            }

            await _customerRepo.RegisterCustomerAsync(customer);
            return true;
        }

        public async Task<bool> RemoveCustomerAsync(int customerId)
        {
            var customerToRemove = await _customerRepo.GetCustomerByIdAsync(customerId);
            if (customerToRemove == null)
            {
                return false;
            }

            await _customerRepo.RemoveCustomerAsync(customerToRemove);
            return true;
        }

        public async Task<bool> UpdateCustomerAsync(int customerId, Customer customer)
        {
            var currentCustomer = await _customerRepo.GetCustomerByIdAsync(customerId);

            if (currentCustomer == null)
            {
                return false;
            }

            currentCustomer.Email = customer.Email;
            currentCustomer.Username = customer.Username;
            currentCustomer.Password = customer.Password;

            _customerRepo.UpdateCustomerAsync(currentCustomer);
            return true;
        }
    }
}
