using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.Entities
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
