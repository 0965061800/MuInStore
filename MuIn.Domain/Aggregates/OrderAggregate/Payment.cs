using System.ComponentModel.DataAnnotations.Schema;

namespace MuIn.Domain.Aggregates.OrderAggregate
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public PayStatus PayStatus { get; set; }
    }
    public enum PayStatus
    {
        Pending = 1,
        Declined = 2,
        Cancelled = 3,
        Refunded = 4,
        Expired = 5,
        Settled = 6
    }
}
