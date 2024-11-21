using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MuInDbContext context) : base(context)
        {

        }
        public bool CheckProductExist(int id)
        {
            bool result = _context.Products.Any(x => x.ProductId == id);
            return result;
        }
    }
}
