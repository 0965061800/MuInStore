namespace MuInShared.Brands
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? BrandImage { get; set; }
        public string Alias { get; set; } = string.Empty;
    }
}
