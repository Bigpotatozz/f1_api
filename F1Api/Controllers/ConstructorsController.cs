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
        [HttpGet("constructors/{year}")]
        public async Task<ActionResult> GetConstructors(int year)
        {

            var resultado = await _context.ConstructorStandings
            .GroupBy(c => c.Race.Year)
            .Select(g => new
                {
                    Year = g.Key,
                    UniqueConstructors = g.Select(c => c.Constructorid).Distinct().Count()
                }).Where(y => y.Year == year)
            .ToListAsync();


            return Ok(resultado);

        }


        [HttpGet("constructors/points/{year}")]
        public async Task<ActionResult> getConstructorsPoints(int year) {

            var resultado = await _context.ConstructorStandings
                .Where(y => y.Race.Year == year)
                .GroupBy(c => c.Constructor.Name)
                .Select(s => new
                {
                    name = s.Key,
                    points = s.Sum(p => p.Points)
                })
             
                .ToListAsync();


            return Ok(resultado);
        }

        [HttpGet("constructors/winners/{year}")]
        public async Task<IActionResult> getConstructorWinners(int year) {

            var totalCarreras2024 = await _context.Races
                                    .Where(r => r.Year == year)
                                    .CountAsync();


            var pointsPerDriver = await _context.Results
                                            .Where(r => r.Position == 1 && r.Race.Year == year)
                                            .GroupBy(r => r.Constructor.Name)
                                            .Select(g => new
                                            {
                                                Code = g.Key,
                                                Victorias = g.Count(),
                                                PorcentajeVictorias = (double)g.Count() * 100 / totalCarreras2024
                                            })
                                            .OrderByDescending(x => x.PorcentajeVictorias)
                                            .ToListAsync();

            return Ok(pointsPerDriver);
        }


        [HttpGet("constructors/champion/{year}")]
        public async Task<IActionResult> getChampion(int year) {

            var champion = await _context.ConstructorStandings
                .Where(c => c.Race.Year == year)
                .GroupBy(c => c.Constructor.Name).Select(g => new
                {
                    ConstructorName = g.Key,
                    points = g.Sum(x => x.Points)
                })
                .OrderByDescending(x => x.points)
                .ToListAsync();


            var result = champion.FirstOrDefault();
            return Ok(result);
        }


        private bool ConstructorExists(int id)
        {
            return _context.Constructors.Any(e => e.Constructorid == id);
        }
    }
}
