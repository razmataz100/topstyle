using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.DTOs
{
    public class ProductAddDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }
    }
}
