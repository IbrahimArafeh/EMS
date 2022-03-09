#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Libarary_DBContext _context;

        public ProductsController(Libarary_DBContext context)
        {
            _context = context;
        }

        // Task Number 1
        // GET: api/Products
        // Get Products Count to Status Name : Sold Or instack or damaged
        [HttpGet]
        public async Task<ActionResult<string>> GetProducts()
        {
            // get List of Status ID with requirements status.
            List<int> status_id = _context.Status.Where(c => c.StatusName == "sold" || c.StatusName == "inStock" || c.StatusName == "damaged").Select(c => c.Id).ToList();
            int procuctsCount = _context.Products.Count(f => status_id.Contains((int)f.StatusId));

            return " the Products Number Of Spacific Status is : " + procuctsCount;
        }

        /// Task Number 2
        // PUT: api/Products/5
        // Update Status to spacific product ID 
   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, int Status)
        {
            var product = _context.Products.Find(id);
            product.StatusId = Status;
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // Task Number 2
        // POST: api/Products
        // Sell Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(int id, int quntity = 0)
        {
            var product = _context.Products.Find(id);
            product.InventoryCount = product.InventoryCount - quntity;
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
