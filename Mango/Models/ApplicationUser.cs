using Microsoft.AspNetCore.Identity;

namespace Mango.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
