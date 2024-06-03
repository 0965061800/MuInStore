using MuInShared.Category;

namespace MuInMVC.Interfaces
{
	public interface ICategoryService
	{
		List<CategoryDto>? GetCategories();
		CategoryFullDto? GetCategoryFull(int id);
	}
}
