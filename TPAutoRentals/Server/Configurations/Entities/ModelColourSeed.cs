using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class ModelColourSeed : IEntityTypeConfiguration<ModelColour>
    {
        public void Configure(EntityTypeBuilder<ModelColour> builder)
        {
            builder.HasData(
                new ModelColour
                {
                    ID = 1,
                    MCImgSide = "prius.jpg",
                    MCName = "Red",
                    MCHexCode = "#ff0000",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelID = 1 // Set the appropriate ModelID
                },
                new ModelColour
                {
                    ID = 2,
                    MCImgSide = "vios.png",
                    MCName = "Blue",
                    MCHexCode = "#0000ff",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelID = 2 // Set the appropriate ModelID
                },
                new ModelColour
                {
                    ID = 3,
                    MCImgSide = "X5.jpg",
                    MCName = "Green",
                    MCHexCode = "#00ff00",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelID = 3 // Set the appropriate ModelID
                },
                new ModelColour
                {
                    ID = 4,
                    MCImgSide = "focus.jpg",
                    MCName = "Yellow",
                    MCHexCode = "#ffff00",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelID = 4, // Set the appropriate ModelID
                },
                new ModelColour
                {
                    ID = 5,
                    MCImgSide = "mustang.jpg",
                    MCName = "Magenta",
                    MCHexCode = "#ff00ff",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ModelID = 5, // Set the appropriate ModelID
                }
            );
        }
    }
}

