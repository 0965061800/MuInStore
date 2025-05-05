using AutoMapper;
using MuIn.Application.Dtos;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Product;

namespace MuIn.Application.MapperConfiguration
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductDto>().ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName)).ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CatName));
			CreateMap<Product, ProductFullDto>()
				.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CatName))
				.ForMember(dest => dest.CommentDtos, opt => opt.MapFrom(src => src.Comments))
				.ForMember(dest => dest.ProductSkuDtos, opt => opt.MapFrom(src => src.ProductSkus))
				;
			CreateMap<RequestProductDto, Product>();
		}
	}
}
