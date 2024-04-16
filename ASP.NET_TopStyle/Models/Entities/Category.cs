using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

    }
}
