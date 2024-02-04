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
    public class LicenseRequestsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public LicenseRequestsController(ApplicationDbContext context)
        public LicenseRequestsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LicenseRequests
        [HttpGet]

        //public async Task<ActionResult<IEnumerable<LicenseRequest>>> GetLicenseRequests()
        public async Task<IActionResult> GetLicenseRequests()
        {
            /*
          if (_context.LicenseRequests == null)
          {
              return NotFound();
          }
            return await _context.LicenseRequests.ToListAsync();
            */

            var LicenseRequests = await _unitOfWork.LicenseRequests.GetAll(includes: q => q.Include(x => x.Customer).Include(x => x.Staff));

            if (LicenseRequests == null)
            {
                return NotFound();
            }
            return Ok(LicenseRequests);
        }

        // GET: api/LicenseRequests/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LicenseRequest>> GetLicenseRequest(int id)
        public async Task<IActionResult> GetLicenseRequest(int id)
        {
            /*
              if (_context.LicenseRequests == null)
              {
                  return NotFound();
              }
                var LicenseRequest = await _context.LicenseRequests.FindAsync(id);

                if (LicenseRequest == null)
                {
                    return NotFound();
                }

                return LicenseRequest;
            */
            var LicenseRequest = await _unitOfWork.LicenseRequests.Get(q => q.ID == id);

            if (LicenseRequest == null)
            {
                return NotFound();
            }


            return Ok(LicenseRequest);
        }

        // PUT: api/LicenseRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenseRequest(int id, LicenseRequest LicenseRequest)
        {
            if (id != LicenseRequest.ID)
            {
                return BadRequest();
            }

            //_context.Entry(LicenseRequest).State = EntityState.Modified;
            _unitOfWork.LicenseRequests.Update(LicenseRequest);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*
                if (!LicenseRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                */
                if (!await LicenseRequestExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/LicenseRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LicenseRequest>> PostLicenseRequest(LicenseRequest LicenseRequest)
        {
            /*
          if (_context.LicenseRequests == null)
          {
              return Problem("Entity set 'ApplicationDbContext.LicenseRequests'  is null.");
          }
            _context.LicenseRequests.Add(LicenseRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicenseRequest", new { id = LicenseRequest.ID }, LicenseRequest);
        */
            await _unitOfWork.LicenseRequests.Insert(LicenseRequest);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetLicenseRequest", new { id = LicenseRequest.ID }, LicenseRequest);
        }

        // DELETE: api/LicenseRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenseRequest(int id)
        {
            /*
            if (_context.LicenseRequests == null)
            {
                return NotFound();
            }
            var LicenseRequest = await _context.LicenseRequests.FindAsync(id);
            */

            var LicenseRequest = await _unitOfWork.LicenseRequests.Get(q => q.ID == id);
            if (LicenseRequest == null)
            {
                return NotFound();
            }

            /*
            _context.LicenseRequests.Remove(LicenseRequest);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.LicenseRequests.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool LicenseRequestExists(int id)
        private async Task<bool> LicenseRequestExists(int id)
        {
            //return (_context.LicenseRequests?.Any(e => e.ID == id)).GetValueOrDefault();
            var LicenseRequest = await _unitOfWork.LicenseRequests.Get(q => q.ID == id);
            return LicenseRequest != null;
        }
    }
}
