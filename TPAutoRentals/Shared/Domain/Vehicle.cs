using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Vehicle : BaseDomainModel
    {
        [Required]
        [RegularExpression(@"^[A-Za-z]{3}\d{4}[A-Za-z]", ErrorMessage = "License Plate Number does not meet requirements")]
        public string? VehPlateNum { get; set; }

        [Required(ErrorMessage = "Vehicle Availability is required")]
        public string? VehAvailability { get; set; }
        [Required]
        [ForeignKey("Outlet")] public int? OutletID { get; set; }
        public virtual Outlet? Outlet { get; set; }

        [Required]
        [ForeignKey("ModelColour")] public int? MCID { get; set; }
        public virtual ModelColour? ModelColour { get; set; }
    }
}
