using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Services.Interfaces;
using ASP.NET_TopStyle.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_TopStyle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILoginService _loginService;

        public AdminController(IAdminService adminService, ILoginService loginService)
        {
            _adminService = adminService;
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AdminLogin(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Invalid admin data.");
            }

            var token = await _loginService.LoginAsync(loginDTO);

            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }

        [HttpPost("addproduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProductAsync(ProductAddDTO productAddDto)
        {
            bool result = await _adminService.AddProductAsync(productAddDto);

            if (result)
            {
                return Ok("Product added successfully.");
            }
            else
            {
                return BadRequest("Failed to add product.");
            }
        }
    }
}
