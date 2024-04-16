using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }
    }
}
