using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public double Price { get; set; }

        public virtual Category Category { get; set; }
    }
}
