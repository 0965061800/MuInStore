using MuInShared.Category;

namespace MuInMVC.Interfaces
{
	public interface ICategoryService
	{
		List<CategoryDto>? GetCategories(int id);
		CategoryFullDto? GetCategoryFull(int id);
	}
}
