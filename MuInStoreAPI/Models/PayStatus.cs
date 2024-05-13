namespace MuInStoreAPI.Models
{
    public class PayStatus
    {
        public int PayStatusId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
