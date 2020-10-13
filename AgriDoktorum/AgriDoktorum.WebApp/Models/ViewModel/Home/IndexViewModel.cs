using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgriDoktorum.WebApp.Models.ViewModel.About;
using AgriDoktorum.WebApp.Models.ViewModel.Contact;
using AgriDoktorum.WebApp.Models.ViewModel.Gallery;
using AgriDoktorum.WebApp.Models.ViewModel.PatientReference;
using AgriDoktorum.WebApp.Models.ViewModel.Treatment;

namespace AgriDoktorum.WebApp.Models.ViewModel.Home
{
    public class IndexViewModel
    {
        public IQueryable<AboutViewModel> AboutView { get; set; }
        public IQueryable<ContactViewModel> ContactView { get; set; }
        public IQueryable<PatientReferenceViewModel> PatientReferenceView { get; set; }
        public IQueryable<TreatmentViewModel> TreatmentView { get; set; }
        public IQueryable<GalleryViewModel> GalleryViews { get; set; }

    }
}