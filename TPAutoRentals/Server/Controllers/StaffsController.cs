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
    public class StaffsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Staffs
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()//
        public async Task<IActionResult> GetStaffs()
        {
            //if (_unitOfWork.Staffs == null)
            //{
            //    return NotFound();
            //}
            //  return await _unitOfWork.Staffs.ToListAsync();
            var Staffs = await _unitOfWork.Staffs.GetAll(includes: q =>q.Include(x => x.Outlet));
            return Ok(Staffs);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Staff>> GetStaff(int id)
        public async Task<IActionResult> GetStaff(int id)
        {
            var Staff = await _unitOfWork.Staffs.Get(q => q.ID == id);

            //if (_unitOfWork.Staffs == null)
            // {
            //return NotFound();
            //}

            //var Staff = await _unitOfWork.Staffs.FindAsync(id);//

            if (Staff == null)
            {
                return NotFound();
            }

            //return Staff;
            return Ok(Staff);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754



        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff Staff)
        {
            if (id != Staff.ID)
            {
                return BadRequest();
            }

            //_unitOfWork.Entry(Staff).State = EntityState.Modified;
            _unitOfWork.Staffs.Update(Staff);
            try
            {
                //await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!StaffExists(id))
                if (!await StaffExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff Staff)
        {
            /*
          if (_unitOfWork.Staffs == null)
          {
              return Problem("Entity set 'IUnitOfWork.Staffs'  is null.");
          }
            _unitOfWork.Staffs.Add(Staff);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = Staff.ID }, Staff);
        */
            await _unitOfWork.Staffs.Insert(Staff);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = Staff.ID }, Staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {   /*
            if (_unitOfWork.Staffs == null)
            {
                return NotFound();
            }
            var Staff = await _unitOfWork.Staffs.FindAsync(id);
            */
            var Staff = await _unitOfWork.Staffs.Get(q => q.ID == id);
            if (Staff == null)
            {
                return NotFound();
            }

            //_unitOfWork.Staffs.Remove(Staff);
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> StaffExists(int id)
        {
            //return (_unitOfWork.Staffs?.Any(e => e.ID == id)).GetValueOrDefault();
            var Staff = await _unitOfWork.Staffs.Get(q => q.ID == id);
            return Staff != null;
        }
    }
}
