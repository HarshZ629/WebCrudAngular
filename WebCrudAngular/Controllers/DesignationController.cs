using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCrudAngular.Model;

namespace WebCrudAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public DesignationController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Designation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblDesignation>>> GettblDesignation()
        {
            return await _context.tblDesignation.ToListAsync();
        }

        // GET: api/Designation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblDesignation>> GettblDesignation(int id)
        {
            var tblDesignation = await _context.tblDesignation.FindAsync(id);

            if (tblDesignation == null)
            {
                return NotFound();
            }

            return tblDesignation;
        }

        // PUT: api/Designation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblDesignation(int id, tblDesignation tblDesignation)
        {
            if (id != tblDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblDesignationExists(id))
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

        // POST: api/Designation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tblDesignation>> PosttblDesignation(tblDesignation tblDesignation)
        {
            _context.tblDesignation.Add(tblDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblDesignation", new { id = tblDesignation.Id }, tblDesignation);
        }

        // DELETE: api/Designation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tblDesignation>> DeletetblDesignation(int id)
        {
            var tblDesignation = await _context.tblDesignation.FindAsync(id);
            if (tblDesignation == null)
            {
                return NotFound();
            }

            _context.tblDesignation.Remove(tblDesignation);
            await _context.SaveChangesAsync();

            return tblDesignation;
        }

        private bool tblDesignationExists(int id)
        {
            return _context.tblDesignation.Any(e => e.Id == id);
        }
    }
}
