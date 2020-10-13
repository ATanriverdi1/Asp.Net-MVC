using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgriDoktorum.WebApp.Models.ViewModel.PatientReference;

namespace AgriDoktorum.WebApp.Models.ViewModel.About
{
    public class AboutIndexViewModel
    {
        public IQueryable<PatientReferenceViewModel> PatientReferenceView { get; set; }
        public IQueryable<AboutViewModel> AboutView { get; set; }
    }
}