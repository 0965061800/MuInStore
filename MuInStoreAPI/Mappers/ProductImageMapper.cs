using MuInShared.Images;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class ProductImageMapper
	{
		public static ProductImageDto ToProductImageDto(this ProductImage productImage)
		{
			return new ProductImageDto
			{
				ProductImageId = productImage.ProductImageId,
				ImageUrl = productImage.ImageUrl,
			};
		}
	}
}
