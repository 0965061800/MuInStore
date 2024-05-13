using System.ComponentModel.DataAnnotations.Schema;

namespace MuInStoreAPI.Models
{
    public class ProductSku
    {
        public int ProductSkuId { get; set; }
        public string Sku { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
