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
    [ApiController]
    [Route("api/[controller]")]
    public class ModelColoursController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelColoursController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetModelColours()
        {
            var modelColours = await _unitOfWork.ModelColours.GetAll(
                includes: q => q.Include(x => x.Model.Brand).Include(x => x.Model.Transport).Include(x => x.Model));

            return Ok(modelColours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelColour(int id)
        {
            var modelColour = await _unitOfWork.ModelColours.Get(q => q.ID == id);

            if (modelColour == null)
            {
                return NotFound();
            }

            return Ok(modelColour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelColour(int id, ModelColour modelColour)
        {
            if (id != modelColour.ID)
            {
                return BadRequest("ID in the URL does not match the ID in the request body.");
            }

            _unitOfWork.ModelColours.Update(modelColour);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ModelColourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Log or handle the exception appropriately
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostModelColour(ModelColour modelColour)
        {
            await _unitOfWork.ModelColours.Insert(modelColour);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetModelColour", new { id = modelColour.ID }, modelColour);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelColour(int id)
        {
            var modelColour = await _unitOfWork.ModelColours.Get(q => q.ID == id);

            if (modelColour == null)
            {
                return NotFound();
            }

            await _unitOfWork.ModelColours.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ModelColourExists(int id)
        {
            var modelColour = await _unitOfWork.ModelColours.Get(q => q.ID == id);
            return modelColour != null;
        }
    }
}
