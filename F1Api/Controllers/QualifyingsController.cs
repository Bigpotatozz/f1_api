using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1Api.Models;

namespace F1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualifyingsController : ControllerBase
    {
        private readonly F1DataContext _context;

        public QualifyingsController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/Qualifyings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qualifying>>> GetQualifyings()
        {
            return await _context.Qualifyings.ToListAsync();
        }

        // GET: api/Qualifyings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qualifying>> GetQualifying(int id)
        {
            var qualifying = await _context.Qualifyings.FindAsync(id);

            if (qualifying == null)
            {
                return NotFound();
            }

            return qualifying;
        }

        // PUT: api/Qualifyings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQualifying(int id, Qualifying qualifying)
        {
            if (id != qualifying.Qualifyid)
            {
                return BadRequest();
            }

            _context.Entry(qualifying).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualifyingExists(id))
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

        // POST: api/Qualifyings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Qualifying>> PostQualifying(Qualifying qualifying)
        {
            _context.Qualifyings.Add(qualifying);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQualifying", new { id = qualifying.Qualifyid }, qualifying);
        }

        // DELETE: api/Qualifyings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualifying(int id)
        {
            var qualifying = await _context.Qualifyings.FindAsync(id);
            if (qualifying == null)
            {
                return NotFound();
            }

            _context.Qualifyings.Remove(qualifying);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualifyingExists(int id)
        {
            return _context.Qualifyings.Any(e => e.Qualifyid == id);
        }
    }
}
