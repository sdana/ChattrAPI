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

namespace ChattrApi.Controllers
{
    [Route("api/message")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<IActionResult> GetMessages([FromHeader] string chatroomName)
        {
            Chatroom currentChat = await _context.Chatroom.Where(chat => chat.Title == chatroomName).FirstOrDefaultAsync();

            IEnumerable<Messages> allMessages = _context.Messages.Where(message => message.ChatroomId == currentChat.ChatroomId).Include(message => message.User);
            return Ok(allMessages);
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messages = await _context.Messages.FindAsync(id);

            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessages([FromRoute] int id, [FromBody] Messages messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messages.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(messages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagesExists(id))
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

        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> PostMessages([FromBody] NewMessage message)
        //public async Task<IActionResult> PostMessages([FromBody] Messages message)
        {
            if (ModelState.IsValid)
            {
                Chatroom currentChat = await _context.Chatroom.Where(chat => chat.Title == message.ChatroomName).FirstOrDefaultAsync();

                Messages newMessage = new Messages
                {
                    ChatroomId = currentChat.ChatroomId,
                    UserId = message.UserId,
                    MessageText = message.MessageText,
                    TimeStamp = DateTime.Now
                };

                _context.Messages.Add(newMessage);

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMessages", new { id = newMessage.MessageId }, newMessage);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messages = await _context.Messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(messages);
            await _context.SaveChangesAsync();

            return Ok(messages);
        }

        private bool MessagesExists(int id)
        {
            return _context.Messages.Any(e => e.MessageId == id);
        }
    }
}