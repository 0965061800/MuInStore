using AutoMapper;
using MuInShared.Product;

namespace MuIn.Application.MapperConfiguration
{
	public class SortFilterPageOptionProfile : Profile
	{
		public SortFilterPageOptionProfile()
		{
			CreateMap<SortFilterPageOptionRequest, SortFilterPageOptions>();
			CreateMap<SortFilterPageOptions, SortFilterPageOptionResponse>();
		}
	}
}
