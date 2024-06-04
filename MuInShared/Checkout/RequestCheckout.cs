using MuInShared.Cart;

namespace MuInShared.Checkout
{
    public class RequestCheckout
    {
        public List<CartItemReponse> cart { get; set; } = new List<CartItemReponse>();
        public CheckoutVM userInfo { get; set; } = new CheckoutVM();
    }
}
