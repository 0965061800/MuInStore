using Microsoft.AspNetCore.Identity;

namespace MuInStoreAPI.Models
{
	public class AppUser : IdentityUser
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public DateTime DOB { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
		public string? Avatar { get; set; }
		public bool Active { get; set; } = true;
		public List<UserLocation> UserLocations { get; set; } = new List<UserLocation>();
		public List<Comment> Comments { get; set; } = new List<Comment>();
		public List<Order> Orders { get; set; } = new List<Order>();
	}
}
