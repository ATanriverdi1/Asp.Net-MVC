using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AgriDoktorum.WebApp.Filter;
using AgriDoktorum.WebApp.Models.Entity;
using AgriDoktorum.WebApp.Models.EntityDb;
using AgriDoktorum.WebApp.Models.ViewModel.About;
using AgriDoktorum.WebApp.Models.ViewModel.PatientReference;

namespace AgriDoktorum.WebApp.Controllers
{
    [RoutePrefix("Hakkımda")]
    public class AboutController : Controller
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        // GET: About
        [Route]
        public ActionResult Index()
        {
            var patientReferences = _context.PatientReferences.Select(i =>
                new PatientReferenceViewModel()
                {
                    ReferenceName = i.ReferenceName,
                    ReferenceSurname = i.ReferenceSurname,
                    ReferenceRemark = i.ReferenceRemark,
                    ReferenceImage = i.ReferenceImage
                }); 
            
            var about = _context.About.Select(i =>
                new AboutViewModel()
                {
                    AboutTitle = i.AboutTitle,
                    AboutDescription = i.AboutDescription
                });

            var aboutIndexModel = new AboutIndexViewModel {AboutView = about, PatientReferenceView = patientReferences};

            return View(aboutIndexModel);
        }

        // GET: About/Edit/5
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = _context.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: About/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Auth]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,AboutTitle,AboutDescription,AboutImage")] About about)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(about).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
