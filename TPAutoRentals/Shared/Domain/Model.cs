using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPAutoRentals.Shared.Domain
{
    public class Model : BaseDomainModel
    {
        [Required(ErrorMessage = "Model Name is required")]
        public string? ModelName { get; set; }

        [Required(ErrorMessage = "Model Year is required")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Model Year should be a 4-digit number")]
        public string? ModelYear { get; set; }

        [Required(ErrorMessage = "Model Body Style is required")]
        public string? ModelBodyStyle { get; set; }

        [Required(ErrorMessage = "Model Seater is required")]
        public string? ModelSeater { get; set; }

        [Required(ErrorMessage = "Model Fuel type is required")]
        public string? ModelFuel { get; set; }

        [Required(ErrorMessage = "Model Transmission type is required")]
        public string? ModelTransmission { get; set; }

        [Required(ErrorMessage = "Booking Cost is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid Hourly Cost format.")]
        public string? ModelCostHourly { get; set; }

        [Required(ErrorMessage = "Daily Cost is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid Daily Cost format")]
        public string? ModelCostDaily { get; set; }

        [Required]
        public string? ModelImage { get; set; }

        [Required]
        [ForeignKey("Transport")]
        public int? TransportID { get; set; }
        public virtual Transport? Transport { get; set; }
        [Required]
        [ForeignKey("Brand")]
        public int? BrandID { get; set; }
        public virtual Brand? Brand { get; set; }

    }
}
