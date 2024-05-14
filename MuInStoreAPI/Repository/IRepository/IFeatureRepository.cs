using MuInStoreAPI.Models;

namespace MuInStoreAPI.Repository.IRepository
{
    public interface IFeatureRepository : IGenericRepository<Feature>
    {
        Task<bool> CheckFeatureId(int id);
    }
}
