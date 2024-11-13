using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Infrastructure;
using MuInStoreAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MuInStoreAPI.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly MuInDbContext _context;
        public ProductRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }



        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Where(x => x.ProductId == id)
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Include(x => x.Comments)
                .ThenInclude(x => x.AppUser)
                .Include(x => x.ProductSkus)
                .ThenInclude(p => p.Color)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProducts(
            Expression<Func<Product, bool>>? filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string? includeProperties = "")
        {
            IQueryable<Product> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (includeProperties.Contains("Category"))
            {

            }

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
    }
}
