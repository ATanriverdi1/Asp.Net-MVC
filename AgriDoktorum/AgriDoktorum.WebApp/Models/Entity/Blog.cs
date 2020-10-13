using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class Blog:MyEntitybase
    {
        public int Id { get; set; }
        public string BlogTittle { get; set; }
        public string BlogText { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImage { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}