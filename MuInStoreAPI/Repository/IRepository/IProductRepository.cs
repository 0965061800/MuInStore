using MuInStoreAPI.Models;

namespace MuInStoreAPI.Repository.IRepository
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		Task<Product?> GetProductByIdAsync(int id);

	}
}
