using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPAutoRentals.Server.Configurations.Entities
{
    public class LicenseRequestSeed : IEntityTypeConfiguration<LicenseRequest>
    {
        public void Configure(EntityTypeBuilder<LicenseRequest> builder)
        {
        }
    }
}

