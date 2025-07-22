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


        private bool ConstructorStandingExists(int id)
        {
            return _context.ConstructorStandings.Any(e => e.Constructorstandingid == id);
        }
    }
}
