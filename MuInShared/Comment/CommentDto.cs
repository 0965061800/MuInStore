namespace MuInShared.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Rate { get; set; }
    }
}
