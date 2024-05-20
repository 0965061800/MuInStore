using MuInShared.Color;
using MuInShared.Images;
using MuInShared.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuInShared.ProductSku
{
	public class ProductSkuFullDto
	{
		public int ProductSkuId { get; set; }
		public string Sku { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal UnitPrice { get; set; }
		public int ColorDtoId { get; set; }
		public ColorDto ColorDto { get; set; }
		public int ProductId { get; set; }
		public ProductDto ProductDto { get; set; }
		public List<ProductImageDto> Images { get; set; }
	}
}
