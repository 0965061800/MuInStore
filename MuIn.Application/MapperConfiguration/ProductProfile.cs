using AutoMapper;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Product;

namespace MuIn.Application.MapperConfiguration
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName)).ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CatName));

        }
    }
}
