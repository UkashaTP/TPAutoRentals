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
    public class CustomersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public CustomersController(ApplicationDbContext context)
        public CustomersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Customers
        [HttpGet]

        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        public async Task<IActionResult> GetCustomers()
        {
            /*
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
            */

            var Customers = await _unitOfWork.Customers.GetAll();

            if (Customers == null)
            {
                return NotFound();
            }
            return Ok(Customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        public async Task<IActionResult> GetCustomer(int id)
        {
            /*
              if (_context.Customers == null)
              {
                  return NotFound();
              }
                var Customer = await _context.Customers.FindAsync(id);

                if (Customer == null)
                {
                    return NotFound();
                }

                return Customer;
            */
            var Customer = await _unitOfWork.Customers.Get(q => q.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }


            return Ok(Customer);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer Customer)
        {
            if (id != Customer.ID)
            {
                return BadRequest();
            }

            //_context.Entry(Customer).State = EntityState.Modified;
            _unitOfWork.Customers.Update(Customer);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                */
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        {
            /*
          if (_context.Customers == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
          }
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = Customer.ID }, Customer);
        */
            await _unitOfWork.Customers.Insert(Customer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustomer", new { id = Customer.ID }, Customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            /*
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var Customer = await _context.Customers.FindAsync(id);
            */

            var Customer = await _unitOfWork.Customers.Get(q => q.ID == id);
            if (Customer == null)
            {
                return NotFound();
            }

            /*
            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CustomerExists(int id)
        private async Task<bool> CustomerExists(int id)
        {
            //return (_context.Customers?.Any(e => e.ID == id)).GetValueOrDefault();
            var Customer = await _unitOfWork.Customers.Get(q => q.ID == id);
            return Customer != null;
        }
    }
}
