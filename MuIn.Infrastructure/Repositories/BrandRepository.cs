using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Infrastructure.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(MuInDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckBrandExist(int id)
        {
            return await _context.Brands.AnyAsync(x => x.BrandId == id);
        }
    }
}
