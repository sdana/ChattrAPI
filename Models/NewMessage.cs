using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class NewMessage
    {

        [Required]
        public string ChatroomName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string MessageText { get; set; }

    }
}
