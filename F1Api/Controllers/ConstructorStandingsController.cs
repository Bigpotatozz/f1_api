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
    public class ConstructorStandingsController : ControllerBase
    {
        private readonly F1DataContext _context;

        public ConstructorStandingsController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/ConstructorStandings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructorStanding>>> GetConstructorStandings()
        {
            return await _context.ConstructorStandings.ToListAsync();
        }

        // GET: api/ConstructorStandings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructorStanding>> GetConstructorStanding(int id)
        {
            var constructorStanding = await _context.ConstructorStandings.FindAsync(id);

            if (constructorStanding == null)
            {
                return NotFound();
            }

            return constructorStanding;
        }

        // PUT: api/ConstructorStandings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructorStanding(int id, ConstructorStanding constructorStanding)
        {
            if (id != constructorStanding.Constructorstandingid)
            {
                return BadRequest();
            }

            _context.Entry(constructorStanding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructorStandingExists(id))
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

        // POST: api/ConstructorStandings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConstructorStanding>> PostConstructorStanding(ConstructorStanding constructorStanding)
        {
            _context.ConstructorStandings.Add(constructorStanding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructorStanding", new { id = constructorStanding.Constructorstandingid }, constructorStanding);
        }

        // DELETE: api/ConstructorStandings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructorStanding(int id)
        {
            var constructorStanding = await _context.ConstructorStandings.FindAsync(id);
            if (constructorStanding == null)
            {
                return NotFound();
            }

            _context.ConstructorStandings.Remove(constructorStanding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructorStandingExists(int id)
        {
            return _context.ConstructorStandings.Any(e => e.Constructorstandingid == id);
        }
    }
}
