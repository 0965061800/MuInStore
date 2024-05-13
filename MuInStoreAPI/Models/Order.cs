using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuInStoreAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SumTotal { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Address { get; set; } = String.Empty;
        public int PaymentId { get; set; }
        public string AppUserId { get; set; }
        public Payment Payment { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
