using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuInShared.ProductSku
{
	public class RequestProductSkuDto
	{
		[Required]
		public string Sku { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal UnitPrice { get; set; }
		public int UnitInStock { get; set; }
		[Required]
		public int ColorId { get; set; }
		[Required]
		public int ProductId { get; set; }
		public string skuImage { get; set; } = string.Empty;
		public string ImageName { get; set; } = string.Empty;
	}
}
