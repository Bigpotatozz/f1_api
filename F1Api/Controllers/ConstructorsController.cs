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
    public class ConstructorsController : ControllerBase
    {
        private readonly F1DataContext _context;

        public ConstructorsController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/Constructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Constructor>>> GetConstructors()
        {
            return await _context.Constructors.ToListAsync();
        }

        // GET: api/Constructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Constructor>> GetConstructor(int id)
        {
            var constructor = await _context.Constructors.FindAsync(id);

            if (constructor == null)
            {
                return NotFound();
            }

            return constructor;
        }

        // PUT: api/Constructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructor(int id, Constructor constructor)
        {
            if (id != constructor.Constructorid)
            {
                return BadRequest();
            }

            _context.Entry(constructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructorExists(id))
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

        // POST: api/Constructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Constructor>> PostConstructor(Constructor constructor)
        {
            _context.Constructors.Add(constructor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructor", new { id = constructor.Constructorid }, constructor);
        }

        // DELETE: api/Constructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructor(int id)
        {
            var constructor = await _context.Constructors.FindAsync(id);
            if (constructor == null)
            {
                return NotFound();
            }

            _context.Constructors.Remove(constructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructorExists(int id)
        {
            return _context.Constructors.Any(e => e.Constructorid == id);
        }
    }
}
