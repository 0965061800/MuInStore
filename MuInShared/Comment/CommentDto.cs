namespace MuInShared.Comment
{
	public class CommentDto
	{
		public int CommentId { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; }
		public int Rate { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
	}
}
