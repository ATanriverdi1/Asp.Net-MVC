﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.ViewModel.Gallery
{
    public class GalleryViewModel
    {
        [Required,StringLength(50)]
        public string Description { get; set; }
        [Required]
        public string VideoUrl { get; set; }
    }
}