using MuIn.Domain.Aggregates.OrderAggregate;

namespace MuIn.Domain.SeedWork.InterfaceRepo
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		//Task<List<Order>?> GetAllOrderAsync();
		//Task<List<Order>?> GetOrdersByUserName(string userName);
	}
}
