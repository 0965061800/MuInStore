namespace MuInShared.Cart
{
    public class CartItem
    {
        public int ProductSkuId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public int ColorId { get; set; }
        public double TotalMoney => (double)(Amount * UnitPrice);

    }
}
