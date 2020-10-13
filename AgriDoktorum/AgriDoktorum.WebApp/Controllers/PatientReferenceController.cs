using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgriDoktorum.WebApp.Filter;
using AgriDoktorum.WebApp.Models.Entity;
using AgriDoktorum.WebApp.Models.EntityDb;

namespace AgriDoktorum.WebApp.Controllers
{
    [RoutePrefix("Hasta_Yorumları")]
    public class PatientReferenceController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PatientReference
        [Route]
        public ActionResult Index()
        {
            return View(db.PatientReferences.ToList());
        }

        // GET: PatientReference/Create
        [Auth]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientReference/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Auth]
        public ActionResult Create([Bind(Include = "Id,ReferenceName,ReferenceSurname,ReferenceRemark,ReferenceImage")] PatientReference patientReference)
        {
            if (ModelState.IsValid)
            {
                db.PatientReferences.Add(patientReference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientReference);
        }

        // GET: PatientReference/Edit/5
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientReference patientReference = db.PatientReferences.Find(id);
            if (patientReference == null)
            {
                return HttpNotFound();
            }
            return View(patientReference);
        }

        // POST: PatientReference/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Auth]
        public ActionResult Edit([Bind(Include = "Id,ReferenceName,ReferenceSurname,ReferenceRemark,ReferenceImage")] PatientReference patientReference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientReference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientReference);
        }

        // GET: PatientReference/Delete/5
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientReference patientReference = db.PatientReferences.Find(id);
            if (patientReference == null)
            {
                return HttpNotFound();
            }
            return View(patientReference);
        }

        // POST: PatientReference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Auth]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientReference patientReference = db.PatientReferences.Find(id);
            db.PatientReferences.Remove(patientReference);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
