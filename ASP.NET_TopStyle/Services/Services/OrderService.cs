using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Interfaces;
using ASP.NET_TopStyle.Services.Interfaces;

namespace ASP.NET_TopStyle.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IProductRepo _productRepo;
        private readonly IOrderRepo _orderRepo;

        public OrderService(ICustomerRepo customerRepo, IProductRepo productRepo, IOrderRepo orderRepo)
        {
            _customerRepo = customerRepo;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
        }

        public async Task<List<ShowOrderDTO>> GetMyOrdersAsync(int currentCustomerId)
        {
            var orders = await _orderRepo.GetOrdersByCustomerIdAsync(currentCustomerId);

            return orders.Select(order => new ShowOrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                CustomerUsername = order.Customer.Username,
                TotalPrice = order.TotalPrice,
                Products = order.OrderProducts.Select(op => new ShowProductDTO
                {
                    ProductId = op.Product.ProductId,
                    Name = op.Product.Name,
                    Description = op.Product.Description,
                    Price = op.Product.Price,
                    CategoryName = op.Product.Category.CategoryName,
                    Quantity = op.Quantity
                }).ToList()
            }).ToList();
        }

        public async Task<bool> PlaceOrderAsync(List<OrderDTO> productsOrdered, int currentCustomerId)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(currentCustomerId);
            if (customer == null)
            {
                return false;
            }

                var order = new Order
                {
                    Customer = customer,
                    OrderDate = DateTime.Now,
                    TotalPrice = 0,
                    OrderProducts = new List<OrderProduct>()
                };

                foreach (var orderDTO in productsOrdered)
                {
                    var product = await _productRepo.GetProductByIdAsync(orderDTO.ProductId);

                    var orderProduct = new OrderProduct
                    {
                        Product = product,
                        Quantity = orderDTO.Quantity,
                        TotalPrice = product.Price * orderDTO.Quantity
                    };

                    order.TotalPrice += orderProduct.TotalPrice;
                    order.OrderProducts.Add(orderProduct);
                }

                await _orderRepo.PlaceOrderAsync(order);
                return true;
        }
    }
}
