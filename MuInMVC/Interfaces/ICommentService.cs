using MuInShared.Comment;

namespace MuInMVC.Interfaces
{
	public interface ICommentService
	{
		Task<string> PostComment(string token, int productId, RequestCommentDto requestCommentDto);
	}
}
