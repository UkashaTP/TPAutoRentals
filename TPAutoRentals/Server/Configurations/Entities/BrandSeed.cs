using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class BrandSeed : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                
                new Brand
                {
                    ID = 1,
                    BrandName = "Toyota",
                    BrandIcon = "Toyota-logo.png",
                    BrandCountry = "Japan",
                    BrandContactNumber = "83298748",
                    BrandWebLink = "https://www.toyota.com.sg/",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Brand
                {
                    ID = 2,
                    BrandName = "BMW",
                    BrandIcon = "BMW.png",
                    BrandCountry = "Germany",
                    BrandContactNumber = "83294810",
                    BrandWebLink = "https://www.bmw.com.sg/",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Brand
                {
                    ID = 3,
                    BrandName = "Ford",
                    BrandIcon = "4611147.png",
                    BrandCountry = "USA",
                    BrandContactNumber = "83294810",
                    BrandWebLink = "https://www.regentmotors.com.sg/",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                
            );
        }
    }
}

