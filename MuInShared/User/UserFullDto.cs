using MuInShared.Order;

namespace MuInShared.User
{
	public class UserFullDto
	{
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public DateTime DOB { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
		public string? Avatar { get; set; }
		public bool Active { get; set; } = true;
		public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
	}
}
