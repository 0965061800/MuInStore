using Microsoft.EntityFrameworkCore;
using MuIn.Application.Interfaces;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;
using MuIn.Infrastructure;

namespace MuIn.Application.CategoryService
{
	public class CategoryListService : AppService, ICatService
	{
		private ICategoryRepository _categoryRepository;
		public CategoryListService(MuInDbContext _context, ICategoryRepository categoryRepository) : base(_context)
		{
			_categoryRepository = categoryRepository;
		}
		public Task<Category?> CreateNewCategory(Category category)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteCategory(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Category>?> GetAllCategory()
		{
			throw new NotImplementedException();
		}

		public async Task<List<Category>?> GetAllChildrenCategory(int id)
		{
			List<Category>? listChildrentCategories = await _db.Categories.Where(x => id == 0 ? x.ParentCatId == null : x.ParentCatId == id).ToListAsync();
			return listChildrentCategories;
		}

		public Task<Category?> UpdateCategory(Category category)
		{
			throw new NotImplementedException();
		}

	}
}
