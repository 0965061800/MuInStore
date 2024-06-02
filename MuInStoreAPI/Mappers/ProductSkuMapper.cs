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
				ColorDto = productSku.Color.ToColorDto(),
				skuImage = productSku.skuImage
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
				ImageName = productSku.ImageName,
				skuImage = productSku.skuImage
			};
		}

		public static ProductSku ToProductSku(this RequestProductSkuDto productSkuDto)
		{
			return new ProductSku
			{
				Sku = productSkuDto.Sku,
				UnitPrice = productSkuDto.UnitPrice,
				UnitInStock = productSkuDto.UnitInStock,
				ColorId = productSkuDto.ColorId,
				ProductId = productSkuDto.ProductId,
				ImageName = productSkuDto.ImageName,
				skuImage = productSkuDto.skuImage,
			};
		}

		public static ProductSku ToUpdateProductSku(this RequestProductSkuDto requestProductSku, ProductSku productSku)
		{
			productSku.Sku = requestProductSku.Sku;
			productSku.ColorId = requestProductSku.ColorId;
			productSku.UnitPrice = requestProductSku.UnitPrice;
			productSku.ImageName = requestProductSku.ImageName;
			productSku.skuImage = requestProductSku.skuImage;
			return productSku;
		}
	}
}
