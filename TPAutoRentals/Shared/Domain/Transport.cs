using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Transport : BaseDomainModel
    {
        [Required(ErrorMessage = "Transport name is required")]
        public string? TransportName { get; set; }
    }

}
