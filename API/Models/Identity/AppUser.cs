using Microsoft.AspNetCore.Identity;

namespace API.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Adress Adress { get; set; }
        
    }
}