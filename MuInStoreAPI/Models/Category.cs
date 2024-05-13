using System.ComponentModel.DataAnnotations;

namespace MuInStoreAPI.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string? CatImage { get; set; }
        public int? ParentCatId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
