using MuIn.Application.ProductService;

namespace MuIn.Application.Interfaces
{
    public interface IListService<T>
    {
        Task<IQueryable<T>> SortFilterPage(SortFilterPageOptions options, int parentCatId);
        Task<IQueryable<T?>> GetById(int id);
        Task<T?> Add(T item);
        Task<T?> Add(T item, int anotherId);
        Task<T?> Update(int id, T item);
        Task<T?> Delete(int id);
    }
}