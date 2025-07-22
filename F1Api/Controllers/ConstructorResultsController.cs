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


        private bool ConstructorResultExists(int id)
        {
            return _context.ConstructorResults.Any(e => e.Constructorresultid == id);
        }
    }
}
