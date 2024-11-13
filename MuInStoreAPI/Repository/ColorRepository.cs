using MuIn.Infrastructure;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        private readonly MuInDbContext _context;
        public ColorRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
