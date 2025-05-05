using MuIn.Domain.Aggregates.ProductAggregate;

namespace MuIn.Domain.SeedWork.InterfaceRepo
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		IQueryable<Product> GetAllProductAsQueryable();
		bool CheckProductExist(int id);
		Task<string?> GetProductImage(int id);
		Task<Product?> UpdateImageAsync(int id, string imageName);
	}
}
