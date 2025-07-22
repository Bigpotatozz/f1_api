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
    public class RacesController : ControllerBase
    {
        private readonly F1DataContext _context;

        public RacesController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/Races
        [HttpGet("races/{year}")]
        public async Task<IActionResult> GetRaces(int year)
        {
          var races =  await _context.Races.GroupBy(r => r.Year).Select(g => new { Year = g.Key, Count = g.Count() }).Where(e => e.Year == year).ToListAsync();

            return Ok(value: races);
        }

        [HttpGet("races/dnf/{year}")]
        public async Task<IActionResult> getDNF(int year) {

            var cantidadDnfs = await _context.Results
                  .Where(r => r.Position == null && r.Race.Year == 2020)
                  .CountAsync();

            var dnf = new
            {
                dnf = cantidadDnfs
            };

            return Ok(dnf);


          
        }


        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.Raceid == id);
        }
    }
}
