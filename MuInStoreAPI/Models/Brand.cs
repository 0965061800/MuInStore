namespace MuInStoreAPI.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? BrandImage { get; set; }
        public string Alias { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
