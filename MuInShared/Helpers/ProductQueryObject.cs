namespace MuInShared.Helpers
{
	public class ProductQueryObject
	{
		public string? BrandAlias { get; set; } = null;
		public int BrandId { get; set; }
		public bool BestSeller { get; set; } = false;
		public string? FeatureAlias { get; set; } = null;
		public int FeatureId { get; set; }
		public string? CategoryAlias { get; set; } = null;
		public int CategoryId { get; set; }
		public bool SortByPrice { get; set; } = false;
		public bool IsDescending { get; set; } = false;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}
}
