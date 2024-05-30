using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuInStoreAPI.Models
{
	public class Category
	{
		[Key]
		public int CatId { get; set; }
		public string CatName { get; set; } = string.Empty;
		public string Alias { get; set; } = string.Empty;
		public string? CatImage { get; set; }
		public string? ImageName { get; set; }
		public string? Description { get; set; }
		public int? ParentCatId { get; set; }
		[NotMapped]
		public Category? Parent { get; set; }
		public List<Category> Subcategories { get; set; } = new List<Category>();
		public List<Product> Products { get; set; } = new List<Product>();
	}
}
