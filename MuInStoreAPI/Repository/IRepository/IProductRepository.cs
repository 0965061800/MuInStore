using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStoreAPI.Repository.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProducts(
            Expression<Func<Product, bool>>? filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string? includeProperties = "");
    }
}
