using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class Chatroom
    {
        [Key]
        public int ChatroomId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool Private { get; set; }
    }
}
