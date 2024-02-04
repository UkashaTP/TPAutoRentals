using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPAutoRentals.Shared.Domain
{
    public class ModelColour : BaseDomainModel
    {
        [Required(ErrorMessage = "Model colour name is required")]
        public string? MCName { get; set; }

        [Required]
        [RegularExpression(@"^#[0-9a-fA-F]{6}$", ErrorMessage = "Colour Hexcode does not meet requirements")]
        public string? MCHexCode { get; set; }

        public string? MCImgFront { get; set; }

        [Required(ErrorMessage = "Please attach an image")]
        public string? MCImgSide { get; set; }

        public string? MCImgBack { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public int? ModelID { get; set; }
        public virtual Model? Model { get; set; }
    }

}
