using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalExamProject.Models
{
    public class Lamp
    {
        public int LampId { get; set; }

        [Required]
        public string LampName { get; set; }

        [Required]
        public string Author { get; set; }

        public int ImageId { get; set; }

        public virtual Image LampImage { get; set; }

        public int Likes { get; set; }
    }
}