using AutoMapper;
using MuIn.Domain.Aggregates;
using MuInShared.Brands;

namespace MuIn.Application.MapperConfiguration
{
	public class BrandProfile : Profile
	{
		public BrandProfile()
		{
			CreateMap<Brand, BrandDto>();
		}
	}
}
