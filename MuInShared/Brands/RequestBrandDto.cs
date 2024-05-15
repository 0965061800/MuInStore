using System.ComponentModel.DataAnnotations;

namespace MuInShared.Brands
{
    public class RequestBrandDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Brand Name has maximum length of 100 charaters")]
        public string BrandName { get; set; }
        public string? BrandImage { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "You need to add Brand Alias")]
        public string Alias { get; set; }
    }
}
