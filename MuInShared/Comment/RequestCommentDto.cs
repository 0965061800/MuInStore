using System.ComponentModel.DataAnnotations;

namespace MuInShared.Comment
{
    public class RequestCommentDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Your title need more than 10 characters")]
        [MaxLength(50, ErrorMessage = "Your title need less than 50 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(20, ErrorMessage = "Your title need more than 20 characters")]
        [MaxLength(200, ErrorMessage = "Your title need less than 200 characters")]
        public string Content { get; set; } = string.Empty;
        [Required]
        public int Rate { get; set; }
    }
}
