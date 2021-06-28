using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenM_Test.Models;
using Microsoft.Extensions.Logging;
using GreenM_Test.Helper;

namespace GreenM_Test.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]    
    [ApiKeyAuth]
    public class LoggedController : ControllerBase
    {
        private readonly test_DBContext _context;

        public LoggedController(test_DBContext context)
        {
            _context = context;
        }

        // GET: api/Logged
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDevicesLogged>>> GetUsersDevicesLoggeds()
        {
            return await _context.UsersDevicesLoggeds.Include(lo => lo.UnexpectedLoggeds)                                                     
                                                     .ToListAsync();
        }

        // GET: api/Logged/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDevicesLogged>> GetUsersDevicesLogged(int id)
        {
            var usersDevicesLogged = _context.UsersDevicesLoggeds.Include(lo => lo.UnexpectedLoggeds)                                                                                                                                   
                                                                 .Where(lo => lo.LoggedId == id)
                                                                 .FirstOrDefault();

            return usersDevicesLogged;
        }        
    }
}
