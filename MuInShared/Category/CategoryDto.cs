namespace MuInShared.Category
{
    public class CategoryDto
    {
        public int CatId { get; set; }
        public string CatName { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string? CatImage { get; set; }
    }
}
