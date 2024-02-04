using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string? CusName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 100 characters.")]
        public string? CusUsername { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z]).*$", ErrorMessage = "Password must contain at least one uppercase letter.")]
        public string? CusPassword { get; set; }

        public string? CusProfileImage { get; set; } = "nopfp.png";

        public string? CusLicenseClass { get; set; } = "NO LICENSE";
    }
}
