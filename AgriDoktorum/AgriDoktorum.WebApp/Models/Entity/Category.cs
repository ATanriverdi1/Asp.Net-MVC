using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string CategoryTitle { get; set; }

        [StringLength(150)]
        public string CategoryDescription { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}