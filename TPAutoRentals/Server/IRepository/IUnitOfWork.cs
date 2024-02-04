using TPAutoRentals.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TPAutoRentals.Server.IRepository;
using TPAutoRentals.Server.Controllers;

namespace TPAutoRentals.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<LicenseRequest> LicenseRequests { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Model> Models { get; }
        IGenericRepository<ModelColour> ModelColours { get; }
        IGenericRepository<Outlet> Outlets { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Transport> Transports { get; }
        IGenericRepository<Vehicle> Vehicles { get; }
    }
}
