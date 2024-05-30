namespace MuInShared.Category
{
	public class CategoryDto
	{
		public int CatId { get; set; }
		public string CatName { get; set; } = string.Empty;
		public string Alias { get; set; } = string.Empty;
		public string? Description { get; set; }
		public string? CatImage { get; set; }
		public string? ImageName { get; set; }
		public List<CategoryDto> SubCategoryDto { get; set; }
	}
}
