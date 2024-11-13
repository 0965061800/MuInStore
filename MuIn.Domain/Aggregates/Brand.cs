using MuIn.Domain.Aggregates.ProductAggregate;

namespace MuIn.Domain.Aggregates
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? BrandImage { get; set; }
        public string Alias { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
/***
 *Business rules:
 *- When delete color, do not remove product
 * 
 * 
 * 
 * ***/