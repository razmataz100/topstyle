using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }
    }
}
