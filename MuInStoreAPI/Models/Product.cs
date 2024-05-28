using System.ComponentModel.DataAnnotations.Schema;

namespace MuInStoreAPI.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		[Column(TypeName = "decimal(18,2)")]
		public decimal ProductPrice { get; set; }
		public string? Description { get; set; }
		public bool BestSeller { get; set; } = false;
		[Column(TypeName = "decimal(2,2)")]
		public decimal Sale { get; set; }
		public string? VideoLink { get; set; }
		public string? specifications { get; set; }
		public string Alias { get; set; } = string.Empty;
		public bool Active { get; set; } = true;
		public DateTime CreatAt { get; set; } = DateTime.Now;
		public string ProductImage { get; set; } = string.Empty;
		public string ImageName { get; set; } = string.Empty;
		public int? FeatureId { get; set; }
		public int? BrandId { get; set; }
		public int? CategoryId { get; set; }
		public Feature? Feature { get; set; }
		public Category? Category { get; set; }
		public Brand? Brand { get; set; }
		public List<ProductSku>? ProductSkus { get; set; }
		public List<Comment>? Comments { get; set; }

	}
}
