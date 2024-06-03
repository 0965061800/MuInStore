using MuInShared.ProductSku;

namespace MuInMVC.Interfaces
{
	public interface IProductSkuService
	{
		ProductSkuDto? GetProductSkuDto(int productId, int colorId);
	}
}
