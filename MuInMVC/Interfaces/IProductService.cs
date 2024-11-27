using MuInShared.Product;

namespace MuInMVC.Interfaces
{
	public interface IProductService
	{
		ProductListCombine? GetProducts(SortFilterPageOptionRequest query);
		ProductFullDto? GetProductById(int id);
	}
}