using Microsoft.AspNetCore.Identity;

namespace ITICoursesManager.Models
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
