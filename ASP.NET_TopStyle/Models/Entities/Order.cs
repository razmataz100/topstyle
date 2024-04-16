using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TopStyle.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
