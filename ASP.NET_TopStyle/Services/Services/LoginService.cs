using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Repository.Interfaces;
using ASP.NET_TopStyle.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.NET_TopStyle.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IAdminRepo _adminRepo;

        public LoginService(ICustomerRepo customerRepo, IAdminRepo adminRepo)
        {
            _customerRepo = customerRepo;
            _adminRepo = adminRepo;
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return null;
            }

            var customerToken = await AuthenticateCustomerAsync(loginDTO);
            if(customerToken != null)
            {
                return customerToken;
            }

            var adminToken = await AuthenticateAdminAsync(loginDTO);
            if (adminToken != null)
            {
                return adminToken;
            }

            return null;
        }

        public async Task<string> AuthenticateCustomerAsync(LoginDTO loginDTO)
        {
            var customer = await _customerRepo.AuthenticateCustomerAsync(loginDTO.Username, loginDTO.Password);
            if (customer != null)
            {
                return GenerateJwtToken(customer.CustomerId, false);
            }

            return null;
        }

        public async Task<string> AuthenticateAdminAsync(LoginDTO loginDTO)
        {
            var customer = await _adminRepo.AuthenticateAdminAsync(loginDTO.Username, loginDTO.Password);
            if (customer != null)
            {
                return GenerateJwtToken(customer.AdminId, true);
            }

            return null;
        }

        public string GenerateJwtToken(int userID, bool isAdmin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userID.ToString()),
                new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "Customer")
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretKey12345!#123456789101112"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
            issuer: "http://localhost:5203/",
            audience: "http://localhost:5203/",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
