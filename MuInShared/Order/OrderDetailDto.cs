using System.ComponentModel.DataAnnotations.Schema;

namespace MuInShared.Order
{
	public class OrderDetailDto
	{
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public int ProductId { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal UnitPrice { get; set; }
		public string ColorName { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public decimal SaleRate { get; set; }
		public decimal Total { get; set; }
	}
}
