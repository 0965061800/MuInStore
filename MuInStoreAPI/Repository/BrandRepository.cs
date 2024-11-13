using Microsoft.EntityFrameworkCore;
using MuIn.Infrastructure;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly MuInDbContext _context;
        public BrandRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> CheckBrandId(int id)
        {
            return await _context.Brands.AnyAsync(s => s.BrandId == id);
        }
    }
}
