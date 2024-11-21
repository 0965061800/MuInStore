using MuIn.Domain.Aggregates;

namespace MuIn.Domain.SeedWork.InterfaceRepo
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> CheckBrandExist(int id);
    }
}
