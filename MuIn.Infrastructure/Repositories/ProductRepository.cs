using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Infrastructure.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(MuInDbContext context) : base(context)
		{

		}

		public IQueryable<Product> GetAllProductAsQueryable()
		{
			return _context.Products.AsQueryable();
		}

		public async Task<string?> GetProductImage(int id)
		{
			var result = await _context.Products.Where(x => x.ProductId == id).Select(x => x.ProductImage).FirstOrDefaultAsync();
			return result;
		}

		public bool CheckProductExist(int id)
		{
			bool result = _context.Products.Any(x => x.ProductId == id);
			return result;
		}

		public async Task<Product?> UpdateImageAsync(int productId, string imageName)
		{
			var product = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
			if (product is not null)
			{
				product.ProductImage = imageName;
				var result = _context.Products.Update(product);
				return result.Entity;
			}
			else return null;
		}

	}
}
