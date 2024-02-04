using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class TransportSeed : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasData(
                new Transport
                {
                    ID = 1,
                    TransportName = "Cars",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new Transport
                {
                    ID = 2,
                    TransportName = "Vans",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new Transport
                {
                    ID = 3,
                    TransportName = "Trucks",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                }, 
                new Transport
                {
                    ID = 4,
                    TransportName = "Buses",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                }
            );
        }
    }
}

