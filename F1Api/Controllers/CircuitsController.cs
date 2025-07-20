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
    public class CircuitsController : ControllerBase
    {
        private readonly F1DataContext _context;

        public CircuitsController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/Circuits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circuit>>> GetCircuits()
        {
            return await _context.Circuits.ToListAsync();
        }

        // GET: api/Circuits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Circuit>> GetCircuit(int id)
        {
            var circuit = await _context.Circuits.FindAsync(id);

            if (circuit == null)
            {
                return NotFound();
            }

            return circuit;
        }

        // PUT: api/Circuits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCircuit(int id, Circuit circuit)
        {
            if (id != circuit.Circuitid)
            {
                return BadRequest();
            }

            _context.Entry(circuit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitExists(id))
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

        // POST: api/Circuits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Circuit>> PostCircuit(Circuit circuit)
        {
            _context.Circuits.Add(circuit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCircuit", new { id = circuit.Circuitid }, circuit);
        }

        // DELETE: api/Circuits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCircuit(int id)
        {
            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }

            _context.Circuits.Remove(circuit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CircuitExists(int id)
        {
            return _context.Circuits.Any(e => e.Circuitid == id);
        }
    }
}
