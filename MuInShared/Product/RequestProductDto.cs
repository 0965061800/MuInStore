using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuInShared.Product
{
    public class RequestProductDto
    {
        [Required]
        [StringLength(120)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string ProductCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bạn cần nhập giá tiền")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        public string? Description { get; set; }
        public bool BestSeller { get; set; } = false;
        [Column(TypeName = "decimal(2,2)")]
        public decimal Sale { get; set; }
        public string? VideoLink { get; set; }
        public string? specifications { get; set; }
        [Required(ErrorMessage = "Chưa nhập biệt hiệu")]
        [StringLength(120)]
        public string Alias { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public int? FeatureId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
    }
}
