using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class OutletSeed : IEntityTypeConfiguration<Outlet>
    {
        public void Configure(EntityTypeBuilder<Outlet> builder)
        {
            builder.HasData(
                new Outlet
                {
                    ID = 1,
                    OutletAddress = "Pasir Ris",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ManagerID = 1, // Set the appropriate ManagerID
                },
                new Outlet
                {
                    ID = 2,
                    OutletAddress = "Tampines",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ManagerID = 2, // Set the appropriate ManagerID
                },
                new Outlet
                {
                    ID = 3,
                    OutletAddress = "Woodlands",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    ManagerID = 3, // Set the appropriate ManagerID
                }
            );
        }
    }
}

