﻿namespace ASP.NET_TopStyle.Models.DTOs
{
    public class ShowProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
    }
}
