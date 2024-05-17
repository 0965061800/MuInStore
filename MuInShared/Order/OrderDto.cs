namespace MuInShared.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public decimal SumTotal { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Address { get; set; }
        public string UserName { get; set; }
        public string? Phone { get; set; }
    }
}
