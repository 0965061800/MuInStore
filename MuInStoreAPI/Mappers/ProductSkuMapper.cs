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
		public static ProductSkuFullDto ToProductSkuFullDto(this ProductSku productSku)
		{
			return new ProductSkuFullDto
			{
				ProductSkuId = productSku.ProductSkuId,
				Sku = productSku.Sku,
				UnitPrice = productSku.UnitPrice,
				ColorDtoId = productSku.ColorId,
				ColorDto = productSku.Color.ToColorDto(),
				ProductId = productSku.ProductId,
				ProductDto = productSku.Product.ToProductDto(),
				Images = productSku.Images.Select(x => x.ToProductImageDto()).ToList(),
			};
		}
	}
}
