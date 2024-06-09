using CarProjectUI.Identity;
using Microsoft.AspNetCore.Identity;

namespace CarProjectUI.Models.Identity
{
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
