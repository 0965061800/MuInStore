namespace MuInStoreAPI.Models
{
    public class CommentImage
    {
        public int CommentImageId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
