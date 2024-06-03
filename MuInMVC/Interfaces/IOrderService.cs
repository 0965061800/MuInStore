using MuInShared.Order;

namespace MuInMVC.Interfaces
{
	public interface IOrderService
	{
		List<OrderFullDto>? GetOrderByUser(string token);
	}
}
