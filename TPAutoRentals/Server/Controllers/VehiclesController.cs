using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPAutoRentals.Server.Data;
using TPAutoRentals.Shared.Domain;
using TPAutoRentals.Server.IRepository;
using TPAutoRentals.Server.Repository;

namespace TPAutoRentals.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public VehiclesController(ApplicationDbContext context)
        public VehiclesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vehicles
        [HttpGet]

        //public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        public async Task<IActionResult> GetVehicles()
        {
            /*
          if (_context.Vehicles == null)
          {
              return NotFound();
          }
            return await _context.Vehicles.ToListAsync();
            */

            var Vehicles = await _unitOfWork.Vehicles.GetAll(includes: q => q.Include(x => x.ModelColour.Model.Brand).Include(x => x.ModelColour.Model.Transport).Include(x => x.Outlet));

            if (Vehicles == null)
            {
                return NotFound();
            }
            return Ok(Vehicles);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        public async Task<IActionResult> GetVehicle(int id)
        {
            /*
              if (_context.Vehicles == null)
              {
                  return NotFound();
              }
                var Vehicle = await _context.Vehicles.FindAsync(id);

                if (Vehicle == null)
                {
                    return NotFound();
                }
            
                return Vehicle;
            */
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.ID == id);

            if (Vehicle == null)
            {
                return NotFound();
            }
            return Ok(Vehicle);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle Vehicle)
        {
            if (id != Vehicle.ID)
            {
                return BadRequest();
            }

            //_context.Entry(Vehicle).State = EntityState.Modified;
            _unitOfWork.Vehicles.Update(Vehicle);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                */
                if (!await VehicleExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle Vehicle)
        {
            /*
          if (_context.Vehicles == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
          }
            _context.Vehicles.Add(Vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = Vehicle.ID }, Vehicle);
        */
            await _unitOfWork.Vehicles.Insert(Vehicle);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVehicle", new { id = Vehicle.ID }, Vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            /*
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            var Vehicle = await _context.Vehicles.FindAsync(id);
            */

            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.ID == id);
            if (Vehicle == null)
            {
                return NotFound();
            }

            /*
            _context.Vehicles.Remove(Vehicle);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Vehicles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool VehicleExists(int id)
        private async Task<bool> VehicleExists(int id)
        {
            //return (_context.Vehicles?.Any(e => e.ID == id)).GetValueOrDefault();
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.ID == id);
            return Vehicle != null;
        }
    }
}