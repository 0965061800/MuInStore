namespace MuInShared.Order
{
    public class OrderFullDto
    {
        public int OrderId { get; set; }
        public decimal SumTotal { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Address { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? TransactionStatus { get; set; }
        public List<OrderDetailDto> orderDetailDtos { get; set; } = new List<OrderDetailDto>();
    }
}
