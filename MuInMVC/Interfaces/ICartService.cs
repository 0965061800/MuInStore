using MuInShared.Cart;

namespace MuInMVC.Interfaces
{
	public interface ICartService
	{
		List<CartItemReponse>? GetCartData(string cartData);
	}
}
