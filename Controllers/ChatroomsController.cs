using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChattrApi.Data;
using ChattrApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;

namespace ChattrApi.Controllers
{
    [Route("api/chatroom")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ChatroomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ChatroomsController(ApplicationDbContext context, UserManager<User> user)
        {
            _userManager = user;
            _context = context;
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: api/Chatrooms
        [HttpGet]
        [Authorize]
        public IEnumerable<Chatroom> GetChatroom()
        {
            string userName = User.Identity.Name;
            //User user = _context.User.Single(u => u.UserName == userName);
            return _context.Chatroom;
        }

        // GET: api/Chatrooms/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetChatroom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatroom = await _context.Chatroom.FindAsync(id);

            if (chatroom == null)
            {
                return NotFound();
            }

            return Ok(chatroom);
        }

        // PUT: api/Chatrooms/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutChatroom([FromRoute] int id, [FromBody] Chatroom chatroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatroom.ChatroomId)
            {
                return BadRequest();
            }

            _context.Entry(chatroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatroomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Chatrooms
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostChatroom([FromBody] Chatroom chatroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Chatroom.Add(chatroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatroom", new { id = chatroom.ChatroomId }, chatroom);
        }

        // DELETE: api/Chatrooms/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteChatroom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatroom = await _context.Chatroom.FindAsync(id);
            if (chatroom == null)
            {
                return NotFound();
            }

            _context.Chatroom.Remove(chatroom);
            await _context.SaveChangesAsync();

            return Ok(chatroom);
        }

        private bool ChatroomExists(int id)
        {
            return _context.Chatroom.Any(e => e.ChatroomId == id);
        }
    }
}