using System.ComponentModel.DataAnnotations;

namespace MuInShared.Category
{
	public class RequestCatDto
	{
		[Required]
		[MaxLength(50, ErrorMessage = "Require maximum 50 charaters")]
		public string CatName { get; set; } = string.Empty;
		[Required]
		[MaxLength(50, ErrorMessage = "Require maximum 50 charaters")]
		public string Alias { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string? CatImage { get; set; }
		public string? ImageName { get; set; }
		public int? ParentCatId { get; set; }
	}
}
