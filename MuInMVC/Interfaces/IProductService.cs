using MuInShared;
using MuInShared.Helpers;
using MuInShared.Product;

namespace MuInMVC.Interfaces
{
	public interface IProductService
	{
		ReponseModel<List<ProductDto>>? GetProducts(ProductQueryObject query);
		ProductFullDto? GetProductById(int id);
	}
}