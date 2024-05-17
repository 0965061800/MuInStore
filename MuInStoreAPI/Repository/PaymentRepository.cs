using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
