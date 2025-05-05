using Microsoft.AspNetCore.Identity;
using MuIn.Domain.Aggregates.OrderAggregate;

namespace MuIn.Domain.Aggregates.UserAggregate
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
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
