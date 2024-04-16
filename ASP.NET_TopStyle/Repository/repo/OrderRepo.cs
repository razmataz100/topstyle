using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Data.Contexts;
using ASP.NET_TopStyle.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_TopStyle.Repository.repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                        .ThenInclude(p => p.Category)
                .Where(o => o.Customer.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task PlaceOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
