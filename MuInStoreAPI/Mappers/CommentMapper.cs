using MuInShared.Comment;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
	public static class CommentMapper
	{
		public static CommentDto ToCommentDto(this Comment comment)
		{
			return new CommentDto
			{
				CommentId = comment.CommentId,
				Content = comment.Content,
				Title = comment.Title,
				Rate = comment.Rate,
				UserId = comment.AppUser.Id,
				UserName = comment.AppUser.UserName,
				CreatedAt = comment.CreatedAt,
			};
		}
		public static Comment ToCommnetFromRequest(this RequestCommentDto requestCommentDto)
		{
			return new Comment
			{
				Title = requestCommentDto.Title,
				Content = requestCommentDto.Content,
				Rate = requestCommentDto.Rate,
			};
		}
	}
}
