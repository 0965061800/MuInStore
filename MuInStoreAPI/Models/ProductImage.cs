namespace MuInStoreAPI.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int ProductSkuId { get; set; }
        public ProductSku ProductSku { get; set; }
    }
}
