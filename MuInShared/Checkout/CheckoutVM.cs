using System.ComponentModel.DataAnnotations;

namespace MuInShared.Checkout
{
    public class CheckoutVM
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và Tên")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Nhập số ĐT đi nè!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Không nhập địa chỉ giao hàng thì sao giao!")]
        public string Address { get; set; }
        public int PaymentID { get; set; }
    }
}
