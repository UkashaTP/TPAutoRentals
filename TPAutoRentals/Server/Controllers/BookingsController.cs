using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPAutoRentals.Server.IRepository;
using TPAutoRentals.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TPAutoRentals.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()//
        public async Task<IActionResult> GetBookings()
        {
            //if (_unitOfWork.Bookings == null)
            //{
            //    return NotFound();
            //}
            //  return await _unitOfWork.Bookings.ToListAsync();
            var Bookings = await _unitOfWork.Bookings.GetAll(includes: q => q.Include(x => x.Customer).Include(x => x.Staff).Include(x => x.Vehicle.ModelColour.Model.Brand).Include(x => x.Vehicle.ModelColour.Model.Transport).Include(x => x.Outlet));
            return Ok(Bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Booking>> GetBooking(int id)
        public async Task<IActionResult> GetBooking(int id)
        {
            var Booking = await _unitOfWork.Bookings.Get(q => q.ID == id);

            //if (_unitOfWork.Bookings == null)
            // {
            //return NotFound();
            //}

            //var Booking = await _unitOfWork.Bookings.FindAsync(id);//

            if (Booking == null)
            {
                return NotFound();
            }


            //return Booking;
            return Ok(Booking);
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754



        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking Booking)
        {
            if (id != Booking.ID)
            {
                return BadRequest();
            }

            //_unitOfWork.Entry(Booking).State = EntityState.Modified;
            _unitOfWork.Bookings.Update(Booking);
            try
            {
                //await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BookingExists(id))
                if (!await BookingExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking Booking)
        {
            /*
          if (_unitOfWork.Bookings == null)
          {
              return Problem("Entity set 'IUnitOfWork.Bookings'  is null.");
          }
            _unitOfWork.Bookings.Add(Booking);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = Booking.ID }, Booking);
        */
            await _unitOfWork.Bookings.Insert(Booking);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBooking", new { id = Booking.ID }, Booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {   /*
            if (_unitOfWork.Bookings == null)
            {
                return NotFound();
            }
            var Booking = await _unitOfWork.Bookings.FindAsync(id);
            */
            var Booking = await _unitOfWork.Bookings.Get(q => q.ID == id);
            if (Booking == null)
            {
                return NotFound();
            }

            //_unitOfWork.Bookings.Remove(Booking);
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> BookingExists(int id)
        {
            //return (_unitOfWork.Bookings?.Any(e => e.ID == id)).GetValueOrDefault();
            var Booking = await _unitOfWork.Bookings.Get(q => q.ID == id);
            return Booking != null;
        }
    }
}
