using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class Brand : BaseDomainModel
    {
        [Required(ErrorMessage = "Brand name cannot be blank")]
        public string? BrandName { get; set; }

        [Required(ErrorMessage = "Please attach an image")]
        public string? BrandIcon { get; set; }

        [Required(ErrorMessage = "Brand country cannot be blank")]
        public string? BrandCountry { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"\d{8}", ErrorMessage = "Phone Number is not a valid phone number")]
        public string? BrandContactNumber { get; set; }

        [Required(ErrorMessage = "Brand Web Link cannot be blank")]
        public string? BrandWebLink { get; set; }
    }
}

