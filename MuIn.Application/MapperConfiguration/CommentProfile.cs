using AutoMapper;
using MuIn.Domain.Aggregates.UserAggregate;
using MuInShared.Comment;

namespace MuIn.Application.MapperConfiguration
{
	public class CommentProfile : Profile
	{
		public CommentProfile()
		{
			CreateMap<Comment, CommentDto>()
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId))
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName));
			;
			CreateMap<RequestCommentDto, Comment>();
		}
	}
}
