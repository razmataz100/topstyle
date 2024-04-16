using ASP.NET_TopStyle.Models.DTOs;
using ASP.NET_TopStyle.Models.Entities;
using ASP.NET_TopStyle.Repository.Data.Contexts;
using ASP.NET_TopStyle.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_TopStyle.Repository.repo
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _context;

        public AdminRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> AuthenticateAdminAsync(string username, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
