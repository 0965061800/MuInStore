using MuInStoreAPI.Models;

namespace MuInStoreAPI.Repository.IRepository
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		Task<List<Order?>> GetOrderByUserName(string userName);

	}
}
