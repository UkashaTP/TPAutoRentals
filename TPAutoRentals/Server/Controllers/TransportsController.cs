using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPAutoRentals.Server.Data;
using TPAutoRentals.Server.IRepository;
using TPAutoRentals.Shared.Domain;

namespace TPAutoRentals.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Transports
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Transport>>> GetTransports()//
        public async Task<IActionResult> GetTransports()
        {
            //if (_unitOfWork.Transports == null)
            //{
            //    return NotFound();
            //}
            //  return await _unitOfWork.Transports.ToListAsync();
            var Transports = await _unitOfWork.Transports.GetAll();
            return Ok(Transports);
        }

        // GET: api/Transports/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Transport>> GetTransport(int id)
        public async Task<IActionResult> GetTransport(int id)
        {
            var Transport = await _unitOfWork.Transports.Get(q => q.ID == id);

            //if (_unitOfWork.Transports == null)
            // {
            //return NotFound();
            //}

            //var Transport = await _unitOfWork.Transports.FindAsync(id);//

            if (Transport == null)
            {
                return NotFound();
            }

            //return Transport;
            return Ok(Transport);
        }

        // PUT: api/Transports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754



        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransport(int id, Transport Transport)
        {
            if (id != Transport.ID)
            {
                return BadRequest();
            }

            //_unitOfWork.Entry(Transport).State = EntityState.Modified;
            _unitOfWork.Transports.Update(Transport);
            try
            {
                //await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TransportExists(id))
                if (!await TransportExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Transports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transport>> PostTransport(Transport Transport)
        {
            /*
          if (_unitOfWork.Transports == null)
          {
              return Problem("Entity set 'IUnitOfWork.Transports'  is null.");
          }
            _unitOfWork.Transports.Add(Transport);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetTransport", new { id = Transport.ID }, Transport);
        */
            await _unitOfWork.Transports.Insert(Transport);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTransport", new { id = Transport.ID }, Transport);
        }

        // DELETE: api/Transports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransport(int id)
        {   /*
            if (_unitOfWork.Transports == null)
            {
                return NotFound();
            }
            var Transport = await _unitOfWork.Transports.FindAsync(id);
            */
            var Transport = await _unitOfWork.Transports.Get(q => q.ID == id);
            if (Transport == null)
            {
                return NotFound();
            }

            //_unitOfWork.Transports.Remove(Transport);
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.Transports.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TransportExists(int id)
        {
            //return (_unitOfWork.Transports?.Any(e => e.ID == id)).GetValueOrDefault();
            var Transport = await _unitOfWork.Transports.Get(q => q.ID == id);
            return Transport != null;
        }
    }
}
