using Microsoft.EntityFrameworkCore;
using MuIn.Infrastructure;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly MuInDbContext _context;
        public CategoryRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CheckCategoryId(int id)
        {
            return await _context.Categories.AnyAsync(s => s.CatId == id);
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            //return await _context.Categories.Include(c => c.Products).Include(c => c.Subcategories).ThenInclude(cc => cc.Products).FirstOrDefaultAsync(c => c.CatId == id);
            return null;
        }
    }
}
