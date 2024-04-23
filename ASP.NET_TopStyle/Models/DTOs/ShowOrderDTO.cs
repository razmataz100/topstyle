using ASP.NET_TopStyle.Models.Entities;

namespace ASP.NET_TopStyle.Models.DTOs
{
    public class ShowOrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerUsername { get; set; }
        public double TotalPrice { get; set; }
        public List<ShowProductInOrderDTO> Products { get; set; }
    }
}
