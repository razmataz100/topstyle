using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Services.Interfaces;
using ASP.NET_TopStyle.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.NET_TopStyle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService  _customerService;
        private readonly ILoginService _loginService;

        public CustomerController(ICustomerService customerService, ILoginService loginService)
        {
            _customerService = customerService;
            _loginService = loginService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(Customer customer)
        {

            bool registrationResult = await _customerService.RegisterCustomerAsync(customer);

            if (!registrationResult)
            {
                return BadRequest("Username already exists. Try again.");
            }

            return Ok("Registered successfully.");
        }

        [HttpDelete("{customerId}")]
        [Authorize]
        public async Task<IActionResult> RemoveUser(int customerId)
        {

            var currentCustomerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentCustomerId != customerId)
            {
                return Unauthorized("Can only delete your own account.");
            }

            bool removalResult = await _customerService.RemoveCustomerAsync(customerId);

            if (!removalResult)
            {
                return NotFound("User not found.");
            }

            return Ok("User removed.");
        }

        [HttpPut("{customerId}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int customerId, Customer customer)
        {

            var currentCustomerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentCustomerId != customerId)
            {
                return Unauthorized("Can only update your own account.");
            }

            bool updateResult = await _customerService.UpdateCustomerAsync(customerId, customer);

            if (!updateResult)
            {
                return NotFound("User not found.");
            }

            return Ok("User updated.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> CustomerLogin(LoginDTO loginDTO)
        {

            var token = await _loginService.LoginAsync(loginDTO);

            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }
    }
}
