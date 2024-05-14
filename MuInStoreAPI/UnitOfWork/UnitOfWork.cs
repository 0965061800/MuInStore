using MuInStoreAPI.Data;
using MuInStoreAPI.Repository;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IProductRepository ProductRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IFeatureRepository FeatureRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            FeatureRepository = new FeatureRepository(_context);
            BrandRepository = new BrandRepository(_context);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
