using MuInStoreAPI.Models;

namespace MuInStoreAPI.Repository.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> CheckCategoryId(int id);
    }
}
