using System.Linq.Expressions;

namespace MuInStoreAPI.Repository.IRepository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAll(
			Expression<Func<T, bool>>? filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string? includeProperties = "");
		Task<T?> GetById(int? id);
		Task<T?> Update(int id, T entity);
		Task Create(T entity);
		Task<T?> Delete(int id);
		Task<T?> DeleteEntity(T entity);

		bool DeleteRange(IEnumerable<T> entities);
	}
}
