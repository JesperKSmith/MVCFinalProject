using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalExamProject.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        [Required]
        public string ImageName { get; set; }
    }
}