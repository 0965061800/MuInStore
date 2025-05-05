namespace MuIn.Domain.Aggregates.OrderAggregate
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? Address { get; set; }
        public int PaymentId { get; set; }
        public string AppUserId { get; set; }
        public Payment Payment { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

/***
 * Business rule:
 * - When initialize an Order, we must initialize a Payment 
 * - We can not delete an Order if we the payment status is completed 
 * 
 * 
 * 
 * **/