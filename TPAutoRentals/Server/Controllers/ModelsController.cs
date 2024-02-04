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
    public class ModelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Models
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Model>>> GetModels()//
        public async Task<IActionResult> GetModels()
        {
            //if (_unitOfWork.Models == null)
            //{
            //    return NotFound();
            //}
            //  return await _unitOfWork.Models.ToListAsync();
            var Models = await _unitOfWork.Models.GetAll(includes: q => q.Include(x => x.Transport).Include(x => x.Brand));
            if (Models == null)
            {
                return NotFound();
            }
            return Ok(Models);
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Model>> GetModel(int id)
        public async Task<IActionResult> GetModel(int id)
        {
            var Model = await _unitOfWork.Models.Get(q => q.ID == id);

            //if (_unitOfWork.Models == null)
            // {
            //return NotFound();
            //}

            //var Model = await _unitOfWork.Models.FindAsync(id);//

            if (Model == null)
            {
                return NotFound();
            }


            //return Model;
            return Ok(Model);
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754



        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model Model)
        {
            if (id != Model.ID)
            {
                return BadRequest();
            }

            //_unitOfWork.Entry(Model).State = EntityState.Modified;
            _unitOfWork.Models.Update(Model);
            try
            {
                //await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ModelExists(id))
                if (!await ModelExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model Model)
        {
            /*
          if (_unitOfWork.Models == null)
          {
              return Problem("Entity set 'IUnitOfWork.Models'  is null.");
          }
            _unitOfWork.Models.Add(Model);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetModel", new { id = Model.ID }, Model);
        */
            await _unitOfWork.Models.Insert(Model);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetModel", new { id = Model.ID }, Model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {   /*
            if (_unitOfWork.Models == null)
            {
                return NotFound();
            }
            var Model = await _unitOfWork.Models.FindAsync(id);
            */
            var Model = await _unitOfWork.Models.Get(q => q.ID == id);
            if (Model == null)
            {
                return NotFound();
            }

            //_unitOfWork.Models.Remove(Model);
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ModelExists(int id)
        {
            //return (_unitOfWork.Models?.Any(e => e.ID == id)).GetValueOrDefault();
            var Model = await _unitOfWork.Models.Get(q => q.ID == id);
            return Model != null;
        }
    }
}
