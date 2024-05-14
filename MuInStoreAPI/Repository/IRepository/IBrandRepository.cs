using MuInStoreAPI.Models;

namespace MuInStoreAPI.Repository.IRepository
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> CheckBrandId(int id);
    }
}
