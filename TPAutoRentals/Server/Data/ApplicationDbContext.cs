using CarRentalManagement.Server.Configurations.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TPAutoRentals.Server.Configurations.Entities;
using TPAutoRentals.Server.Models;
using TPAutoRentals.Shared.Domain;

namespace TPAutoRentals.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet<Booking> Bookings {  get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LicenseRequest> LicenseRequests { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelColour> ModelColours { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BrandSeed());
            builder.ApplyConfiguration(new CustomerSeed());
            builder.ApplyConfiguration(new ModelColourSeed());
            builder.ApplyConfiguration(new ModelSeed());
            builder.ApplyConfiguration(new OutletSeed());
            builder.ApplyConfiguration(new RoleSeed());
            builder.ApplyConfiguration(new StaffSeed());
            builder.ApplyConfiguration(new TransportSeed());
            builder.ApplyConfiguration(new UserRoleSeed());
            builder.ApplyConfiguration(new UserSeed());
        }

    }
}
