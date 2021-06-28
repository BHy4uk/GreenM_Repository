using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenM_Test.Models;
using GreenM_Test.Helper;

namespace GreenM_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class UsersRegistrationsController : ControllerBase
    {
        private readonly test_DBContext _context;

        public UsersRegistrationsController(test_DBContext context)
        {
            _context = context;
        }

        // GET: api/UsersRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersRegistration>>> GetUsersRegistrations()
        {
            return await _context.UsersRegistrations.ToListAsync();
        }

        // GET: api/UsersRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersRegistration>> GetUsersRegistration(int id)
        {
            var usersRegistration = await _context.UsersRegistrations.FindAsync(id);

            if (usersRegistration == null)
            {
                return NotFound();
            }

            return usersRegistration;
        }

        [HttpGet("GetUsersRegistrationSpecified/{id}")]
        public async Task<ActionResult<UsersRegistration>> GetUsersRegistrationSpecified(int id)
        {
            var usersRegistration = _context.UsersRegistrations
                                                                .Include(mo => mo.DevicesRegistrations)
                                                                .Include(mo => mo.Month)                                                                                                                               
                                                                .Where(mo => mo.MonthId == id)
                                                                .FirstOrDefault();
                                                                

            if (usersRegistration == null)
            {
                return NotFound();
            }

            return usersRegistration;
        }

        private bool UsersRegistrationExists(int id)
        {
            return _context.UsersRegistrations.Any(e => e.MonthId == id);
        }
    }
}
