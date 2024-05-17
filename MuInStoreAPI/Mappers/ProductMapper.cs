using MuInShared.Product;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class ProductMapper
	{
		public static ProductDto ToProductDto(this Product ProductModel)
		{
			return new ProductDto
			{
				ProductId = ProductModel.ProductId,
				ProductName = ProductModel.ProductName,
				ProductCode = ProductModel.ProductCode,
				ProductPrice = ProductModel.ProductPrice,
				Description = ProductModel.Description,
				BestSeller = ProductModel.BestSeller,
				Sale = ProductModel.Sale,
				VideoLink = ProductModel.VideoLink,
				Alias = ProductModel.Alias,
				FeatureName = ProductModel.Feature?.FeatureName,
				BrandName = ProductModel.Brand?.BrandName,
				CategoryName = ProductModel.Category?.CatName
			};
		}
		public static Product ToProduct(this RequestProductDto requestProductDto)
		{
			return new Product
			{
				ProductName = requestProductDto.ProductName,
				ProductCode = requestProductDto.ProductCode,
				ProductPrice = requestProductDto.ProductPrice,
				Description = requestProductDto.Description,
				BestSeller = requestProductDto.BestSeller,
				Sale = requestProductDto.Sale,
				VideoLink = requestProductDto.VideoLink,
				specifications = requestProductDto.specifications,
				Alias = requestProductDto.Alias,
				FeatureId = requestProductDto.FeatureId,
				BrandId = requestProductDto.BrandId,
				CategoryId = requestProductDto.CategoryId,
			};
		}

		public static Product UpdateToProduct(this UpdateProductDto updateProductDto, Product product)
		{
			product.ProductName = updateProductDto.ProductName;
			product.ProductCode = updateProductDto.ProductCode;
			product.ProductPrice = updateProductDto.ProductPrice;
			product.Description = updateProductDto.Description;
			product.BestSeller = updateProductDto.BestSeller;
			product.Sale = updateProductDto.Sale;
			product.VideoLink = updateProductDto.VideoLink;
			product.specifications = updateProductDto.specifications;
			product.Alias = updateProductDto.Alias;
			product.FeatureId = updateProductDto.FeatureId;
			product.BrandId = updateProductDto.BrandId;
			product.CategoryId = updateProductDto.CategoryId;
			return product;
		}

		public static ProductFullDto ToProductFullDto(this Product product)
		{
			return new ProductFullDto
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				ProductCode = product.ProductCode,
				ProductPrice = product.ProductPrice,
				Description = product.Description,
				BestSeller = product.BestSeller,
				Sale = product.Sale,
				VideoLink = product.VideoLink,
				Alias = product.Alias,
				ProductImage = product.ProductImage,
				FeatureId = product.FeatureId,
				FeatureName = product.Feature?.FeatureName,
				BrandId = product.BrandId,
				BrandName = product.Brand?.BrandName,
				CategoryId = product.CategoryId,
				CategoryName = product.Category?.CatName,
				ProductSkuDtos = product.ProductSkus.Select(x => x.ToProductSkuDto()).ToList(),
				Active = product.Active,
				specifications = product.specifications,
				CommentDtos = product.Comments.Select(c => c.ToCommentDto()).ToList(),
				averageRating = product.Comments.Any() ? (decimal)product.Comments.Average(c => c.Rate) : 0,

			};
		}
	}
}
