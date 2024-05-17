using MuInShared.ProductSku;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class ProductSkuMapper
	{
		public static ProductSkuDto ToProductSkuDto(this ProductSku productSku)
		{
			return new ProductSkuDto
			{
				ProductSkuId = productSku.ProductSkuId,
				Sku = productSku.Sku,
				UnitPrice = productSku.UnitPrice,
				ColorDtoId = productSku.ColorId,
				ColorDto = productSku.Color.ToColorDto()
			};
		}
	}
}
