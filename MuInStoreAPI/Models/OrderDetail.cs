﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MuInStoreAPI.Models
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public int ProductId { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal UnitPrice { get; set; }
		public string ColorName { get; set; } = string.Empty;
		public int OrderId { get; set; }
		public int ProductSkuId { get; set; }
		public int Quantity { get; set; }
		[Column(TypeName = "decimal(2,2)")]
		public decimal SaleRate { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Total { get; set; }
		public Order Order { get; set; }
		public ProductSku ProductSku { get; set; }
	}
}
