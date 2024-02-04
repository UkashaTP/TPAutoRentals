using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string? StaffName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "User Name does not meet length requirements")]
        public string? StaffUsername { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z]).*$", ErrorMessage = "Password must contain at least one uppercase letter.")]
        public string? StaffPassword { get; set; }

        [Required(ErrorMessage = "Please select a staff role")]
        public string? StaffRole { get; set; }

        [Required(ErrorMessage = "Please select staff status")]
        public string? StaffStatus { get; set; }

        public string? StaffProfileImage { get; set; } = "nopfp.png";

        public int? OutletID { get; set; }
        public virtual Outlet? Outlet { get; set; }

    }

}
