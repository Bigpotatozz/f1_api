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
    public class DriverStandingsController : ControllerBase
    {
        private readonly F1DataContext _context;

        public DriverStandingsController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/DriverStandings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverStanding>>> GetDriverStandings()
        {
            return await _context.DriverStandings.ToListAsync();
        }

        // GET: api/DriverStandings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverStanding>> GetDriverStanding(int id)
        {
            var driverStanding = await _context.DriverStandings.FindAsync(id);

            if (driverStanding == null)
            {
                return NotFound();
            }

            return driverStanding;
        }

        // PUT: api/DriverStandings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverStanding(int id, DriverStanding driverStanding)
        {
            if (id != driverStanding.Driverstanding)
            {
                return BadRequest();
            }

            _context.Entry(driverStanding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverStandingExists(id))
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

        // POST: api/DriverStandings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverStanding>> PostDriverStanding(DriverStanding driverStanding)
        {
            _context.DriverStandings.Add(driverStanding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverStanding", new { id = driverStanding.Driverstanding }, driverStanding);
        }

        // DELETE: api/DriverStandings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverStanding(int id)
        {
            var driverStanding = await _context.DriverStandings.FindAsync(id);
            if (driverStanding == null)
            {
                return NotFound();
            }

            _context.DriverStandings.Remove(driverStanding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverStandingExists(int id)
        {
            return _context.DriverStandings.Any(e => e.Driverstanding == id);
        }
    }
}
