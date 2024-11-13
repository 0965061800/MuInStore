using MuIn.Infrastructure;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly MuInDbContext _context;
        public OrderDetailRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
