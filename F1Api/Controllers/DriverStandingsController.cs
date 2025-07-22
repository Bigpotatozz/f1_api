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

        private bool DriverStandingExists(int id)
        {
            return _context.DriverStandings.Any(e => e.Driverstanding == id);
        }
    }
}
