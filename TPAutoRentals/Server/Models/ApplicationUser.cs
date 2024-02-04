using Microsoft.AspNetCore.Identity;

namespace TPAutoRentals.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        //internal string FirstName;

        public string? Name { get; internal set; }

        // internal string LastName;
    }
}
