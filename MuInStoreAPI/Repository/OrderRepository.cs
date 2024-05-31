using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _context;
		public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}
		public async Task<List<Order>?> GetOrderByUserName(string userName)
		{
			var order = await _context.Orders.Include("AppUser").Where(o => o.AppUser.UserName == userName).ToListAsync();
			return order;
		}
	}
}
