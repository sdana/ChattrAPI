using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class Chatroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatroomId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool Private { get; set; }

        public string UserId { get; set; }
    }
}
