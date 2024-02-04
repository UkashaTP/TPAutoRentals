using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class StaffSeed : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    ID = 1,
                    StaffName = "Bryan Tan",
                    StaffUsername = "Bryan1234",
                    StaffPassword = "Bryan1234",
                    StaffRole = "Manager",
                    StaffStatus = "Available",
                    StaffProfileImage = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    OutletID = 1, // Set the appropriate OutletID
                },
                new Staff
                {
                    ID = 2,
                    StaffName = "Ukasha Putra Samad",
                    StaffUsername = "Ukasha1234",
                    StaffPassword = "Ukasha1234",
                    StaffRole = "Manager",
                    StaffStatus = "Available",
                    StaffProfileImage = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    OutletID = 2, // Set the appropriate OutletID
                },
                new Staff
                {
                    ID = 3,
                    StaffName = "Tom",
                    StaffUsername = "Tom1234",
                    StaffPassword = "Tom1234",
                    StaffRole = "Chauffeur",
                    StaffStatus = "Available",
                    StaffProfileImage = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    OutletID = 3, // Set the appropriate OutletID
                },
                new Staff
                {
                    ID = 4,
                    StaffName = "James",
                    StaffUsername = "James1234",
                    StaffPassword = "James1234",
                    StaffRole = "Chauffeur",
                    StaffStatus = "Available",
                    StaffProfileImage = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    OutletID = 1 // Set the appropriate OutletID
                },
                new Staff
                {
                    ID = 5,
                    StaffName = "Harry",
                    StaffUsername = "Harry1234",
                    StaffPassword = "Harry1234",
                    StaffRole = "Chauffeur",
                    StaffStatus = "Available",
                    StaffProfileImage = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    OutletID = 3, // Set the appropriate OutletID
                }
            );
        }
    }
}

