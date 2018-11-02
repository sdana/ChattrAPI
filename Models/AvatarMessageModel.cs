using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Models
{
    public class AvatarMessageModel
    {
        [NotMapped]
        public string User { get; set; }

        [NotMapped]
        public string avatar { get; set; }

        [NotMapped]
        public string message { get; set; }

    }
}
