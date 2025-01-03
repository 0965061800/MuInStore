using MuIn.Application.Interfaces;
using MuIn.Domain.Aggregates;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Application.CategoryService
{
	public class CategoryListService : ICatService
	{
		private ICategoryRepository _categoryRepository;
		public CategoryListService(ICategoryRepository categoryRepository)
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
			List<Category>? listChildrentCategories = await _categoryRepository.GetAllChildrenCategory(id);
			return listChildrentCategories;
		}

		public Task<Category?> UpdateCategory(Category category)
		{
			throw new NotImplementedException();
		}

	}
}
