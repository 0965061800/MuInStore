using MuIn.Domain.Aggregates;

namespace MuIn.Application.Interfaces
{
	public interface ICatService
	{
		Task<List<Category>?> GetAllCategory();
		Task<List<Category>?> GetAllChildrenCategory(int id);
		Task<Category?> CreateNewCategory(Category category);
		Task<Category?> UpdateCategory(Category category);
		Task<bool> DeleteCategory(int id);
	}
}
