namespace MuInShared.Helpers
{
	public class ProductQueryObject
	{
		public string? BrandName { get; set; } = null;
		public string? CatName { get; set; } = null;
		public bool SortByPrice { get; set; } = false;
		public bool IsDescending { get; set; } = false;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}
}
