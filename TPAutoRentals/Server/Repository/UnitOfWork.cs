using TPAutoRentals.Server.Data;
using TPAutoRentals.Server.IRepository;
using TPAutoRentals.Server.Models;
using TPAutoRentals.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TPAutoRentals.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Booking> _bookings;
        private IGenericRepository<Brand> _brands;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<LicenseRequest> _licenserequests;
        private IGenericRepository<Model> _models;
        private IGenericRepository<ModelColour> _modelcolours;
        private IGenericRepository<Outlet> _outlets;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<Transport> _transports;
        private IGenericRepository<Vehicle> _vehicles;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Booking> Bookings
            => _bookings ??= new GenericRepository<Booking>(_context);
        public IGenericRepository<Brand> Brands
            => _brands ??= new GenericRepository<Brand>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<LicenseRequest> LicenseRequests
            => _licenserequests ??= new GenericRepository<LicenseRequest>(_context);
        public IGenericRepository<Model> Models
            => _models ??= new GenericRepository<Model>(_context);
        public IGenericRepository<ModelColour> ModelColours
            => _modelcolours ??= new GenericRepository<ModelColour>(_context);
        public IGenericRepository<Outlet> Outlets
            => _outlets ??= new GenericRepository<Outlet>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Transport> Transports
            => _transports ??= new GenericRepository<Transport>(_context);
        public IGenericRepository<Vehicle> Vehicles
            => _vehicles ??= new GenericRepository<Vehicle>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
