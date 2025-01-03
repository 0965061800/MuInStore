using AutoMapper;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.ProductSku;

namespace MuIn.Application.MapperConfiguration
{
	public class ProductSkuProfile : Profile
	{
		public ProductSkuProfile()
		{
			CreateMap<ProductSku, ProductSkuDto>()
				.ForMember(dest => dest.ColorDtoId, opt => opt.MapFrom(src => src.ColorId))
				.ForMember(dest => dest.ColorDto, opt => opt.MapFrom(src => src.Color))
				;
		}
	}
}
