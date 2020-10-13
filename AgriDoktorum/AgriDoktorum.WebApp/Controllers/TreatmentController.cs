using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgriDoktorum.WebApp.Filter;
using AgriDoktorum.WebApp.Models.Entity;
using AgriDoktorum.WebApp.Models.EntityDb;

namespace AgriDoktorum.WebApp.Controllers
{
    [RoutePrefix("migren_tedavisi")]
    public class TreatmentController : Controller
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        // GET: Treatment
        [Route]
        public ActionResult Index()
        {
            return View(_context.Treatments.ToList());
        }

        // GET: Treatment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = _context.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: Treatment/Create
        [Auth]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Auth]
        public ActionResult Create([Bind(Include = "Id,TreatmentTitle,TreatmentText")] Treatment treatment, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var extension = Path.GetExtension(file.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        var folder = Server.MapPath("~/upload/Treatment");
                        var randomfilename = Path.GetFileName(file.FileName);
                        var filename = Path.ChangeExtension(randomfilename, ".jpg");

                        treatment.TreatmentImage = filename;

                        var path = Path.Combine(folder, filename);

                        file.SaveAs(path);
                    }
                    else
                    {
                        ViewData["message"] = "Resim dosyası seçiniz.";
                    }
                }
                else
                {
                    ViewData["message"] = "Bir dosya seçiniz";
                }
                _context.Treatments.Add(treatment);
                _context.SaveChanges();
                return RedirectToAction("TreatmentView", "AdminView");
            }

            return View(treatment);
        }

        // GET: Treatment/Edit/5
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = _context.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Auth]
        public ActionResult Edit([Bind(Include = "Id,TreatmentTitle,TreatmentText")] Treatment treatment, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var extension = Path.GetExtension(file.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        var folder = Server.MapPath("~/upload/Treatment");
                        var randomfilename = Path.GetFileName(file.FileName);
                        var filename = Path.ChangeExtension(randomfilename, ".jpg");

                        treatment.TreatmentImage = filename;

                        var path = Path.Combine(folder, filename);

                        file.SaveAs(path);
                    }
                    else
                    {
                        ViewData["message"] = "Resim dosyası seçiniz.";
                    }
                }
                else
                {
                    ViewData["message"] = "Bir dosya seçiniz";
                }
                _context.Entry(treatment).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("TreatmentView", "AdminView");
            }
            return View(treatment);
        }

        // GET: Treatment/Delete/5
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = _context.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Auth]
        public ActionResult DeleteConfirmed(int id)
        {
            Treatment treatment = _context.Treatments.Find(id);
            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
            return RedirectToAction("TreatmentView", "AdminView");
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
