using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Outlet : BaseDomainModel
    {
        [Required(ErrorMessage = "Outlet address is required")]
        public string? OutletAddress { get; set; }

        [ForeignKey("Staff")] public int? ManagerID { get; set; }
        public virtual Staff? Staff { get; set; }
    }

}
