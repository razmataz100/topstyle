using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Repository.Interfaces
{
    public interface IOrderRepo
    {
        Task PlaceOrderAsync(Order order);
        Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId);
    }
}
