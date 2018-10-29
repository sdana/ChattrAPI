using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public int ChatroomId { get; set; }

        public Chatroom Chatroom { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
