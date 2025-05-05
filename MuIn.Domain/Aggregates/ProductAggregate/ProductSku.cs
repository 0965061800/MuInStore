using MuIn.Domain.Aggregates.OrderAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuIn.Domain.Aggregates.ProductAggregate
{
    public class ProductSku
    {
        public int ProductSkuId { get; set; }
        public string Sku { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int? ColorId { get; set; }
        public int ProductId { get; set; }
        public string skuImage { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public Product Product { get; set; }
        public Color? Color { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
