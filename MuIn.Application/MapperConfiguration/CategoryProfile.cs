using AutoMapper;
using MuIn.Domain.Aggregates;
using MuInShared.Category;

namespace MuIn.Application.MapperConfiguration
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryDto>()
				.ForMember(x => x.SubCategoryDto, opt => opt.MapFrom(src => src.Subcategories));
		}
	}
}
