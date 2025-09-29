using Microsoft.AspNetCore.Identity;

namespace WebNet.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserNome { get; set; }
        public string? Role { get; set; }
    }
}