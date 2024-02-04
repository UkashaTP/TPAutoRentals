using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class ModelSeed : IEntityTypeConfiguration<Model>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Model> builder)
        {
            builder.HasData(
                new Model
                {
                    ID = 1,
                    ModelName = "Prius",
                    ModelYear = "2018",
                    ModelBodyStyle = "Sedan",
                    ModelSeater = "5-Seater",
                    ModelFuel = "Hybrid Petrol",
                    ModelTransmission = "Automatic",
                    ModelCostHourly = "6",
                    ModelCostDaily = "88",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelImage = "prius.jpg",
                    TransportID = 1, 	// Set the appropriate TransportID
                    BrandID = 1,    	// Set the appropriate BrandID
                },
                new Model
                {
                    ID = 2,
                    ModelName = "Vios",
                    ModelYear = "2020",
                    ModelBodyStyle = "Sedan",
                    ModelSeater = "5-Seater",
                    ModelFuel = "Petrol",
                    ModelTransmission = "Automatic",
                    ModelCostHourly = "5",
                    ModelCostDaily = "70",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelImage = "vios.png",
                    TransportID = 1, 	// Set the appropriate TransportID
                    BrandID = 1,    	// Set the appropriate BrandID
                },
                new Model
                {
                    ID = 3,
                    ModelName = "X5",
                    ModelYear = "2022",
                    ModelBodyStyle = "SUV",
                    ModelSeater = "7-Seater",
                    ModelFuel = "Petrol",
                    ModelTransmission = "Automatic",
                    ModelCostHourly = "10",
                    ModelCostDaily = "130",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelImage = "X5.jpg",
                    TransportID = 2, 	// Set the appropriate TransportID
                    BrandID = 2,    	// Set the appropriate BrandID
                },
                new Model
                {
                    ID = 4,
                    ModelName = "Focus",
                    ModelYear = "1998",
                    ModelBodyStyle = "Station Wagon",
                    ModelSeater = "5-Seater",
                    ModelFuel = "Petrol",
                    ModelTransmission = "Manual",
                    ModelCostHourly = "4",
                    ModelCostDaily = "60",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelImage = "focus.jpg",
                    TransportID = 1, 	// Set the appropriate TransportID
                    BrandID = 3,    	// Set the appropriate BrandID
                },
                new Model
                {
                    ID = 5,
                    ModelName = "Mustang",
                    ModelYear = "2020",
                    ModelBodyStyle = "Coupe",
                    ModelSeater = "5-Seater",
                    ModelFuel = "Petrol",
                    ModelTransmission = "Automatic",
                    ModelCostHourly = "15",
                    ModelCostDaily = "250",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelImage = "mustang.jpg",
                    TransportID = 1, 	// Set the appropriate TransportID
                    BrandID = 3,    	// Set the appropriate BrandID
                }
                ); ;
        }
    }
}

