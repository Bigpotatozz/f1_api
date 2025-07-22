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
    public class DriversController : ControllerBase
    {
        private readonly F1DataContext _context;

        public DriversController(F1DataContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet("drivers/{year}")]
        public async Task<IActionResult> GetDrivers(int year)
        {
    
            var cantidadPilotos = await _context.DriverStandings.GroupBy(ds => ds.Race.Year).Select(g => new {
                Year = g.Key,
                UniqueDrivers = g.Select(ds => ds.Driverid).Distinct().Count()
            }).Where(y => y.Year == year).ToListAsync();

            return Ok(cantidadPilotos);
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        [HttpGet("drivers/points/{year}")]
        public async Task<IActionResult> getDriversPoints(int year) { 
        
            var pointsPerDriver = await _context.DriverStandings
                                    .Where(ds => ds.Race.Year == year)
                                    .GroupBy(ds => ds.Driver.Code)
                                    .Select(g => new
                                    {
                                        Code = g.Key,
                                        TotalPoints = g.Sum(x => x.Points)
                                    })
                                    .ToListAsync();

            return Ok(pointsPerDriver);
        }

        [HttpGet("drivers/winners/{year}")]
        public async Task<IActionResult> getWinnerDrivers(int year)
        {

            var totalCarreras2024 = await _context.Races
                                        .Where(r => r.Year == year)
                                        .CountAsync();


            var pointsPerDriver = await _context.Results
                                            .Where(r => r.Position == 1 && r.Race.Year == year)
                                            .GroupBy(r => r.Driver.Code)
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

        [HttpGet("drivers/champion/{year}")]
        public async Task<IActionResult> getChampion(int year) {

            var champion = await _context.DriverStandings
                .Where(y => y.Race.Year == year)
                .GroupBy(d => d.Driver.Code)
                .Select(g => new
                {
                    code = g.Key,
                    points = g.Sum(x => x.Points)
                })
                .OrderByDescending(c => c.points)
                .ToListAsync();

            var resultado = champion.FirstOrDefault();

            return Ok(resultado);
        }




        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Driverid == id);
        }
    }
}
