using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class FavoritePeople
    {
        [Key]
        public int FavoritePeopleId { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string FriendId { get; set; }

    }
}
