using MuInShared.Category;
using MuInShared.Product;

namespace MuInMVC.ModelViews
{
	public class ProductHomeVM
	{
		public CategoryDto Category { get; set; }
		public List<ProductDto> lsProducts { get; set; }

	}
}
