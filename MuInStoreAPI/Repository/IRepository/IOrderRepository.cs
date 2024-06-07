using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStoreAPI.Repository.IRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>?> GetOrderByUserName(string userName);
        Task<List<Order>?> GetAllOrderAsync(Expression<Func<Order, bool>>? filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null);
        Task<Order?> GetOrderById(int id);
    }
}
