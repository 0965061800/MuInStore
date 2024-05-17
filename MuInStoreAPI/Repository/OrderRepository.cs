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
    }
}
