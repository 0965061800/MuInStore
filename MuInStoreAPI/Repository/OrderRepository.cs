using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MuInStoreAPI.Repository
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _context;
		public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}
		public async Task<List<Order>?> GetAllOrderAsync(Expression<Func<Order, bool>>? filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null)
		{
			IQueryable<Order> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			query = query.Include(x => x.Payment).ThenInclude(x => x.PayStatus);
			if (orderBy != null)
			{
				query = orderBy(query);
				return await query.ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}
		public async Task<List<Order>?> GetOrderByUserName(string userName)
		{
			var order = await _context.Orders.Include(x => x.AppUser).Where(o => o.AppUser.UserName == userName).Include(x => x.Payment).ThenInclude(x => x.PayStatus).ToListAsync();
			return order;
		}

		public async Task<Order?> GetOrderById(int id)
		{
			var order = await _context.Orders.Where(o => o.OrderId == id).Include(o => o.AppUser).Include(o => o.Payment).ThenInclude(o => o.PayStatus).Include(o => o.OrderDetails).FirstOrDefaultAsync();
			return order;
		}
	}
}
