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
        private bool CircuitExists(int id)
        {
            return _context.Circuits.Any(e => e.Circuitid == id);
        }
    }
}
