using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Booking : BaseDomainModel
    {
        [Required(ErrorMessage = "Please select a bookin type")]
        public string? BookType { get; set; }

        [Required(ErrorMessage = "Booking Cost is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Booking Cost must be a positive number with up to 2 decimal places.")]
        public string? BookCost { get; set; }

        [Required(ErrorMessage = "Please select a booking payment")]
        public string? BookPayment { get; set; }

        [Required(ErrorMessage = "Date and Time of booking in cannot be blank")]
        public DateTime? BookDTIn { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Date and Time of booking out cannot be blank")]
        public DateTime? BookDTOut { get; set; } = DateTime.Now;

        public string? BookComments { get; set; }

        [Required(ErrorMessage = "Booking status cannot be left blank")]
        public string? BookStatus { get; set; } = "PENDING";
        [Required]
        [ForeignKey("Outlet")] public int? OutletExReturn { get; set; }
        public virtual Outlet? Outlet { get; set; }
        [Required]
        [ForeignKey("Customer")] public int? CusID { get; set; }
        public virtual Customer? Customer { get; set; }
        
        [ForeignKey("Staff")] public int? StaffID { get; set; }
        public virtual Staff? Staff { get; set; }

        [ForeignKey("Vehicle")] public int? VehID { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        
    }
}