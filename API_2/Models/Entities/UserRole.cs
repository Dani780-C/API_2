using Microsoft.AspNetCore.Identity;

namespace API_2.Models.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
