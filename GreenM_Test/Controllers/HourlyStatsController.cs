using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenM_Test.Models;

namespace GreenM_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourlyStatsController : ControllerBase
    {
        private readonly test_DBContext _context;

        public HourlyStatsController(test_DBContext context)
        {
            _context = context;
        }

        // GET: api/HourlyStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TotalAccumulatedDuration>>> GetTotalAccumulatedDurations()
        {
            return await _context.TotalAccumulatedDurations.ToListAsync();
        }

        // GET: api/HourlyStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TotalAccumulatedDuration>> GetTotalAccumulatedDuration(int id)
        {
            var totalAccumulatedDuration = await _context.TotalAccumulatedDurations.FindAsync(id);

            if (totalAccumulatedDuration == null)
            {
                return NotFound();
            }

            return totalAccumulatedDuration;
        }

        

        private bool TotalAccumulatedDurationExists(int id)
        {
            return _context.TotalAccumulatedDurations.Any(e => e.SessDurId == id);
        }
    }
}
