using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Model
{
    public class ApplicationUser : IdentityUser
    {
        private string Firstname { get; set; }
        private string Lastname { get; set; }
    }
}
