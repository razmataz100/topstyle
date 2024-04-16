using ASP.NET_TopStyle.Models.DTOs;

namespace ASP.NET_TopStyle.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> PlaceOrderAsync(List<OrderDTO> productsOrdered, int currentCustomerId);
        Task<List<ShowOrderDTO>> GetMyOrdersAsync(int currentCustomerId);
    }
}
