namespace MuIn.Domain.SeedWork.InterfaceRepo
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int Id);
        Task<T?> CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<T?> Delete(int Id);
        Task SaveChange();
    }
}
