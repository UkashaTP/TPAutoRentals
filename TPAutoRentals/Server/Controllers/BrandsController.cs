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
    public class BrandsController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IUnitOfWork _unitOfWork;

        public BrandsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brands
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()//
        public async Task<IActionResult> GetBrands()
        {
            //if (_unitOfWork.Brands == null)
            //{
            //    return NotFound();
            //}
            //  return await _unitOfWork.Brands.ToListAsync();
            var Brands = await _unitOfWork.Brands.GetAll();
            return Ok(Brands);
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Brand>> GetBrand(int id)
        public async Task<IActionResult> GetBrand(int id)
        {
            var Brand = await _unitOfWork.Brands.Get(q => q.ID == id);

            //if (_unitOfWork.Brands == null)
            // {
            //return NotFound();
            //}

            //var Brand = await _unitOfWork.Brands.FindAsync(id);//

            if (Brand == null)
            {
                return NotFound();
            }

            //return Brand;
            return Ok(Brand);
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754



        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand Brand)
        {
            if (id != Brand.ID)
            {
                return BadRequest();
            }

            //_unitOfWork.Entry(Brand).State = EntityState.Modified;
            _unitOfWork.Brands.Update(Brand);
            try
            {
                //await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BrandExists(id))
                if (!await BrandExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand Brand)
        {
            /*
          if (_unitOfWork.Brands == null)
          {
              return Problem("Entity set 'IUnitOfWork.Brands'  is null.");
          }
            _unitOfWork.Brands.Add(Brand);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = Brand.ID }, Brand);
        */
            await _unitOfWork.Brands.Insert(Brand);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBrand", new { id = Brand.ID }, Brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {   /*
            if (_unitOfWork.Brands == null)
            {
                return NotFound();
            }
            var Brand = await _unitOfWork.Brands.FindAsync(id);
            */
            var Brand = await _unitOfWork.Brands.Get(q => q.ID == id);
            if (Brand == null)
            {
                return NotFound();
            }

            //_unitOfWork.Brands.Remove(Brand);
            //await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.Brands.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> BrandExists(int id)
        {
            //return (_unitOfWork.Brands?.Any(e => e.ID == id)).GetValueOrDefault();
            var Brand = await _unitOfWork.Brands.Get(q => q.ID == id);
            return Brand != null;
        }

        /*
        [HttpPost("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            bool Results = false;
            try
            {
                var _uploadedfiles = Request.Form.Files;
                foreach (IFormFile source in _uploadedfiles)
                {
                    string Filename = source.FileName;
                    string Filepath = "~\\..\\..\\Client\\wwwroot\\Images\\BrandIcons";

                    string imagepath = Filepath + "\\" + Filename;

                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await source.CopyToAsync(stream);
                        Results = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Ok(Results);
        }

        [NonAction]
        private string GetFilePath(string ProductCode)
        {
            return this._environment.WebRootPath + "\\Uploads\\Product\\" + ProductCode;
        }
        */
    }
}
