using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        
    }
}