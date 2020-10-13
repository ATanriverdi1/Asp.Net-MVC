using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class MyEntitybase
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        [Required, StringLength(30)]
        public string ModifiedUsername { get; set; }
    }
}