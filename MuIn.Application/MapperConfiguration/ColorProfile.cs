using AutoMapper;
using MuIn.Domain.Aggregates;
using MuInShared.Color;

namespace MuIn.Application.MapperConfiguration
{
	public class ColorProfile : Profile
	{
		public ColorProfile()
		{
			CreateMap<Color, ColorDto>();
		}
	}
}
