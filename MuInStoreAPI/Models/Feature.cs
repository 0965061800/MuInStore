namespace MuInStoreAPI.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
