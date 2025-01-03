using MuIn.Application.Dtos;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Cart;
using MuInShared.Product;

namespace MuIn.Application.Interfaces
{
	public interface IProductServices
	{
		Task<ProductListCombine> SortFilterPage(SortFilterPageOptionRequest sortFilterPageRequest);
		Task<ProductFullDto> GetById(int id);
		Task<Product?> Add(Product item);
		Task<ProductDto?> Add(RequestProductDto item, int anotherId, string imageName);
		Task<Product?> Update(int id, Product item);
		Task<Product?> Delete(int id);
		Task<List<CartItemReponse>> GetCartItemInfo(List<AddToCartVM> cartItems);
	}
}
