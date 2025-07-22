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


        [HttpGet("qualy/poles/{year}")]
        public async Task<IActionResult> getPoles(int year) {

            var poles = await _context.Qualifyings
                .Where(y => y.Race.Year == year && y.Position == 1)
                .GroupBy(d => d.Driver.Code).Select(g => new
                {
                    code = g.Key,
                    poles = g.Count()
                })
                .ToListAsync();

            return Ok(poles);

        }
    
    
      

        private bool QualifyingExists(int id)
        {
            return _context.Qualifyings.Any(e => e.Qualifyid == id);
        }
    }
}
