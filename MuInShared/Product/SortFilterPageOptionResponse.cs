namespace MuInShared.Product
{
	public class SortFilterPageOptionResponse
	{
		public int PageNum { get; set; }
		public int PageSize { get; set; }
		public int NumPages { get; set; }
		public OrderProductByOptions OrderByOptions { get; set; }
		public ProductFilterBy FilterBy { get; set; }
		public string? FilterValue { get; set; }
		public int? CatId { get; set; }
	}
}
