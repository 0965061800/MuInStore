using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IBrandRepository BrandRepository { get; }

        Task Save();
    }
}
