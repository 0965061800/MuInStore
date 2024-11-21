using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MuInDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckCatExist(int id)
        {
            return await _context.Categories.AnyAsync(x => x.CatId == id);
        }

        public async Task<List<int>> FindCatIdAndAllSubCatId(int parentId)
        {

            List<int> catIdList = new();
            if (parentId != null)
            {
                catIdList.Add(parentId);
                int i = 0;
                while (i < catIdList.Count)
                {
                    var ParentCat = await _context.Categories.Include(x => x.Subcategories).FirstOrDefaultAsync(x => x.CatId == catIdList[i]);
                    if (ParentCat.Subcategories.Any())
                    {
                        List<int> findCatIdList = ParentCat.Subcategories.Select(x => x.CatId).ToList();
                        catIdList.AddRange(findCatIdList);
                    }
                    i++;
                }
            }
            return catIdList;
        }


    }
}
