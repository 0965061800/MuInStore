﻿namespace MuInShared.Order
{
	public class OrderDto
	{
		public int OrderId { get; set; }
		public decimal SumTotal { get; set; }
		public DateTime CreateDate { get; set; }
		public string? TransactionStatus { get; set; }
	}
}
