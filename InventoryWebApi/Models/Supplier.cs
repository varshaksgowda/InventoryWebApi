﻿namespace InventoryWebApi.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string Name { get; set; } = null!;

        public string ContactInfo { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}