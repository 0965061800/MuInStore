using MuIn.Infrastructure;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly MuInDbContext _context;
        public PaymentRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
