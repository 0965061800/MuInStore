using MuInShared.Product;

namespace MuInShared.Category
{
	public class CategoryFullDto
	{
		public int CatId { get; set; }
		public string CatName { get; set; } = string.Empty;
		public string Alias { get; set; } = string.Empty;
		public string? CatImage { get; set; }
		public string? ImageName { get; set; }
		public string? Description { get; set; }
		public List<ProductDto>? AllProducts { get; set; }
		public List<CategoryDto>? SubCategories { get; set; }
	}
}
