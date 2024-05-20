namespace MuInShared.Cart
{
	public class CartItemReponse
	{
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? ProductImage { get; set; }
		public int ProductSkuId { get; set; }
		public decimal UnitPrice { get; set; }
		public int Amount { get; set; }
		public int ColorId { get; set; }
		public string? ColorName { get; set; }
		public double TotalMoney => (double)(Amount * UnitPrice);

	}
}
