using KickyLegs.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KickyLegs.Web.DataContext
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext():base("DefaultConnection", throwIfV1Schema: false)
        {
                
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}