using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.Entity
{
    public class Treatment
    {
        public int Id { get; set; }
        public string TreatmentTitle { get; set; }
        public string TreatmentText { get; set; }
        public string TreatmentImage { get; set; }

    }
}