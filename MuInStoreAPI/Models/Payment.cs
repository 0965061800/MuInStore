using System.ComponentModel.DataAnnotations.Schema;

namespace MuInStoreAPI.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public int PayStatusId { get; set; }
        public PayStatus PayStatus { get; set; }
    }
}
