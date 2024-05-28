namespace MuInShared.Helpers
{
	public class ProductQueryObject
	{
		public string? BrandAlias { get; set; } = null;
		public string? FeatureAlias { get; set; } = null;
		public bool SortByPrice { get; set; } = false;
		public bool IsDescending { get; set; } = false;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}
}
