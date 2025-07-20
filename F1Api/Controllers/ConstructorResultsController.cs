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
    public class ConstructorResultsController : ControllerBase
    {
        private readonly F1DataContext _context;

        public ConstructorResultsController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/ConstructorResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructorResult>>> GetConstructorResults()
        {
            return await _context.ConstructorResults.ToListAsync();
        }

        // GET: api/ConstructorResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructorResult>> GetConstructorResult(int id)
        {
            var constructorResult = await _context.ConstructorResults.FindAsync(id);

            if (constructorResult == null)
            {
                return NotFound();
            }

            return constructorResult;
        }

        // PUT: api/ConstructorResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructorResult(int id, ConstructorResult constructorResult)
        {
            if (id != constructorResult.Constructorresultid)
            {
                return BadRequest();
            }

            _context.Entry(constructorResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructorResultExists(id))
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

        // POST: api/ConstructorResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConstructorResult>> PostConstructorResult(ConstructorResult constructorResult)
        {
            _context.ConstructorResults.Add(constructorResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructorResult", new { id = constructorResult.Constructorresultid }, constructorResult);
        }

        // DELETE: api/ConstructorResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructorResult(int id)
        {
            var constructorResult = await _context.ConstructorResults.FindAsync(id);
            if (constructorResult == null)
            {
                return NotFound();
            }

            _context.ConstructorResults.Remove(constructorResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructorResultExists(int id)
        {
            return _context.ConstructorResults.Any(e => e.Constructorresultid == id);
        }
    }
}
