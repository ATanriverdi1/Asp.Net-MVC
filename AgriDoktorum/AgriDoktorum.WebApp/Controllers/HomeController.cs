using System.Linq;
using System.Web.Mvc;
using AgriDoktorum.WebApp.Models.EntityDb;
using AgriDoktorum.WebApp.Models.ViewModel.About;
using AgriDoktorum.WebApp.Models.ViewModel.Contact;
using AgriDoktorum.WebApp.Models.ViewModel.Gallery;
using AgriDoktorum.WebApp.Models.ViewModel.PatientReference;
using AgriDoktorum.WebApp.Models.ViewModel.Treatment;
using IndexViewModel = AgriDoktorum.WebApp.Models.ViewModel.Home.IndexViewModel;

namespace AgriDoktorum.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            var about = _context.About.Select(i =>
                new AboutViewModel()
                {
                    AboutTitle = i.AboutTitle,
                    AboutDescription = i.AboutDescription
                });

            var contact = _context.Contact.Select(i =>
                new ContactViewModel()
                {
                    Address = i.Address,
                    TelNo = i.TelNo,
                    Email = i.Email
                });

            var patientReferences = _context.PatientReferences.Select(i =>
                new PatientReferenceViewModel()
                {
                    ReferenceName = i.ReferenceName,
                    ReferenceSurname = i.ReferenceSurname,
                    ReferenceRemark = i.ReferenceRemark,
                    ReferenceImage = i.ReferenceImage
                });

            var treatments = _context.Treatments.Select(i =>
                new TreatmentViewModel()
                {
                    Id = i.Id,
                    TreatmentTitle = i.TreatmentTitle,
                    TreatmentText = i.TreatmentText,
                    TreatmentImage = i.TreatmentImage
                });

            var galleries = _context.Galleries.Select(i =>
            new GalleryViewModel()
            {
                Description = i.Description,
                VideoUrl = i.VideoUrl
            });


            var viewModel = new IndexViewModel
            {
                AboutView = about,
                ContactView = contact,
                PatientReferenceView = patientReferences,
                TreatmentView = treatments,
                GalleryViews = galleries
            };

            return View(viewModel);
        }
    }
}