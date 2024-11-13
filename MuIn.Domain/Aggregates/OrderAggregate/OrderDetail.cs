using MuIn.Domain.Aggregates.ProductAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuIn.Domain.Aggregates.OrderAggregate
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductSkuId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public ProductSku ProductSku { get; set; }
    }
}


/****
 * Business rules:
 * - Check if the product is not for sale: throw alert
 * - Check if the product quantity is shorter or equal 0: throw alert
 * - Check if the prodcut quantity is higher than 10: throw alert
 * 
 * 
 * 
 * **/
