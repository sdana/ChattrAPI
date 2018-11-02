using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChattrApi.Models
{
    public class EditUser
    {
        [Key]
        public string UserId { get; set; }

        [NotMapped]
        public string UserName { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string FirstName { get; set; }

        [NotMapped]
        public string LastName { get; set; }
    }
}
