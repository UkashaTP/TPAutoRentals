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
    public class OutletsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OutletsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Outlets
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Outlet>>> GetOutlets()//
        public async Task<IActionResult> GetOutlets()
        {
            //if (_unitOfWork.Outlets == null)
            //{
            //    return NotFound();
            //}
            //  return await _unitOfWork.Outlets.ToListAsync();
            var Outlets = await _unitOfWork.Outlets.GetAll(includes: q => q.Include(x => x.Staff));
            return Ok(Outlets);
        }

        // GET: api/Outlets/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Outlet>> GetOutlet(int id)
        public async Task<IActionResult> GetOutlet(int id)
        {
            var Outlet = await _unitOfWork.Outlets.Get(q => q.ID == id);

            //if (_unitOfWork.Outlets == null)
            // {
            //return NotFound();
            //}

            //var outlet = await _unitOfWork.Outlets.FindAsync(id);//

            if (Outlet == null)
            {
                return NotFound();
            }

            //return outlet;
            return Ok(Outlet);
        }

        // PUT: api/Outlets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754



        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutlet(int id, Outlet Outlet)
        {
            if (id != Outlet.ID)
            {
                return BadRequest();
            }

            //_unitOfWork.Entry(outlet).State = EntityState.Modified;
            _unitOfWork.Outlets.Update(Outlet);
            try
            {
                //await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OutletExists(id))
                if (!await OutletExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Outlets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Outlet>> PostOutlet(Outlet Outlet)
        {
            /*
          if (_unitOfWork.Outlets == null)
          {
              return Problem("Entity set 'IUnitOfWork.Outlets'  is null.");
          }
            _unitOfWork.Outlets.Add(outlet);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetOutlet", new { id = outlet.ID }, outlet);
        */
            await _unitOfWork.Outlets.Insert(Outlet);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOutlet", new { id = Outlet.ID }, Outlet);
        }

        // DELETE: api/Outlets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutlet(int id)
        {   /*
            if (_unitOfWork.Outlets == null)
            {
                return NotFound();
            }
            var outlet = await _unitOfWork.Outlets.FindAsync(id);
            */
            var Outlet = await _unitOfWork.Outlets.Get(q => q.ID == id);
            if (Outlet == null)
            {
                return NotFound();
            }

            //_unitOfWork.Outlets.Remove(outlet);
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.Outlets.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> OutletExists(int id)
        {
            //return (_unitOfWork.Outlets?.Any(e => e.ID == id)).GetValueOrDefault();
            var Outlet = await _unitOfWork.Outlets.Get(q => q.ID == id);
            return Outlet != null;
        }
    }
}
