using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class ChatAllowedUsers
    {
        [Key]
        public int ChatAllowedUsersId { get; set; }

        [Required]
        public int ChatRoomId { get; set; }
        public Chatroom Chatroom { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
