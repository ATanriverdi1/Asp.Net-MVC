using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.ViewModel.PatientReference
{
    public class PatientReferenceViewModel
    {
        public string ReferenceName { get; set; }
        public string ReferenceSurname { get; set; }
        public string ReferenceRemark { get; set; }
        public string ReferenceImage { get; set; }
    }
}