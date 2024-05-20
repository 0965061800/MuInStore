using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Data;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
	public class ProductSkuRepository : GenericRepository<ProductSku>, IProductSkuRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductSkuRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}
		public override Task<ProductSku?> GetById(int? id)
		{
			_context.ProductSkus.Where(p => p.ProductSkuId == id)
				.Include(p => p.Color)
				.Include(p => p.Product)
				.Include(p => p.Images)
				.ToList();
			return base.GetById(id);
		}

	}
}
