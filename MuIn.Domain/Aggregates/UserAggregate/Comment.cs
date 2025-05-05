namespace MuIn.Domain.Aggregates.UserAggregate
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
