using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    ID = 1,
                    CusName = "John Tan",
                    CusUsername = "John1234",
                    CusPassword = "John1234",
                    CusLicenseClass = "NO LICENSE",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Customer
                { 
                    ID = 2,
                    CusName = "Shaun Goh",
                    CusUsername = "Shaun1234",
                    CusPassword = "Shaun1234",
                    CusLicenseClass = "NO LICENSE",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Customer
                {
                    ID = 3,
                    CusName = "Alvin Lim",
                    CusUsername = "Alvin1234",
                    CusPassword = "Alvin1234",
                    CusLicenseClass = "NO LICENSE",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            );
        }
    }
}


