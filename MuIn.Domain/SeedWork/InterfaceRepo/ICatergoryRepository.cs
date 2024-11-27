using MuIn.Domain.Aggregates;

namespace MuIn.Domain.SeedWork.InterfaceRepo
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<int>> FindCatIdAndAllSubCatId(int parentId);
        Task<bool> CheckCatExist(int id);
        Task<List<Category>> GetAllParentCategory();
    }
}
