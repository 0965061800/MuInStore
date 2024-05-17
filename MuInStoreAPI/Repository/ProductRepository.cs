using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}

		public async Task<Product?> GetProductByIdAsync(int id)
		{
			return await _context.Products
				.Where(x => x.ProductId == id)
				.Include(x => x.Category)
				.Include(x => x.Brand)
				.Include(x => x.Feature)
				.Include(x => x.Comments)
				.Include(x => x.ProductSkus)
				.ThenInclude(p => p.Color)
				.FirstOrDefaultAsync();
		}
	}
}
