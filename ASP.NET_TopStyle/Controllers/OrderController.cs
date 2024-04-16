using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Interfaces;
using ASP.NET_TopStyle.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.NET_TopStyle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("placeorder")]
        public async Task<IActionResult> PlaceOrder(List<OrderDTO> productsOrdered)
        {
            var currentCustomerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var orderResult = await _orderService.PlaceOrderAsync(productsOrdered, currentCustomerId);

            if(orderResult == true) 
            {
                return Ok("Order placed successfully.");
            }
            else
            {
                return BadRequest("Failed to place order");
            }
        }

        [HttpGet("myorders")]
        public async Task<IActionResult> GetOrders()
        {

                var currentCustomerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var orders = await _orderService.GetMyOrdersAsync(currentCustomerId);

            if(orders == null)
            {
                return NotFound("You do not have any earlier orders");
            }

            return Ok(orders);

  

            
        }
    }
}
