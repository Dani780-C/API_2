using Microsoft.AspNetCore.Identity;

namespace API_2.Models.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
