using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
