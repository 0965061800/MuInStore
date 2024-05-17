using MuInShared.Color;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuInShared.ProductSku
{
    public class ProductSkuDto
    {
        public int ProductSkuId { get; set; }
        public string Sku { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int ColorDtoId { get; set; }
        public ColorDto ColorDto { get; set; }
    }
}
