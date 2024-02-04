using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class LicenseRequest : BaseDomainModel
    {
        [Required(ErrorMessage = "Please attach an image")]
        public string? LReqImage { get; set; }

        public string? LReqStatus { get; set; }
        [Required]
        [ForeignKey("Customer")] public int? CusID { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Staff")] public int? StaffID { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
