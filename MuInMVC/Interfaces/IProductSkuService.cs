using MuInShared.ProductSku;

namespace MuInMVC.Interfaces
{
	public interface IProductSkuService
	{
		Task<ProductSkuDto?> GetProductSkuDto(int productId, int colorId);
	}
}
