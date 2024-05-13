namespace MuInStoreAPI.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public List<ProductSku> ProductSkus { get; set; } = new List<ProductSku>();
    }
}
