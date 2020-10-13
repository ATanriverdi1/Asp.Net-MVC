using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class AdUser
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Surname { get; set; }

        [Required, StringLength(25)]
        public string Username { get; set; }

        [Required, StringLength(70)]
        public string Email { get; set; }

        [Required, StringLength(25)]
        public string Password { get; set; }

    }
}