using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChattrApi.Data;
using ChattrApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ChattrApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context, UserManager<User> user)
        {
            _userManager = user;
            _context = context;
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            string userName = User.Identity.Name;
            User user = _context.User.Single(u => u.UserName == userName);
            return Ok(user);
        }

    }
}