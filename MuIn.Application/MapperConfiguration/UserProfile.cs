using AutoMapper;
using MuIn.Domain.Aggregates.UserAggregate;
using MuInShared.User;

namespace MuIn.Application.MapperConfiguration
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<AppUser, UserInfoDto>()
				.ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.UserName))
				;
		}
	}
}
