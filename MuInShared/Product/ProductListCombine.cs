namespace MuInShared.Product
{
	public class ProductListCombine
	{
		public ProductListCombine(SortFilterPageOptionResponse sortFilterPageData, IEnumerable<ProductDto> productList)
		{
			SortFilterPageData = sortFilterPageData;
			ProductList = productList;
		}

		public SortFilterPageOptionResponse SortFilterPageData { get; private set; }

		public IEnumerable<ProductDto> ProductList { get; private set; }
	}
}
