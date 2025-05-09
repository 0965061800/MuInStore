﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MuInShared.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        public string? Description { get; set; }
        public bool BestSeller { get; set; } = false;
        [Column(TypeName = "decimal(2,2)")]
        public decimal Sale { get; set; }
        public string? VideoLink { get; set; }
        public string? Specifications { get; set; }
        public string Alias { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public string ProductImage { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
    }
}
