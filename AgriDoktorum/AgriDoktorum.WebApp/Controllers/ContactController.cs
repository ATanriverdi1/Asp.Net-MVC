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
    [RoutePrefix("İletişim")]
    public class ContactController : Controller
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        // GET: Contact
        [Route]
        public ActionResult Index()
        {
            return View(_context.Contact.ToList());
        }

        // GET: Contact/Edit/5
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _context.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth]
        public ActionResult Edit([Bind(Include = "Id,Address,TelNo,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(contact).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
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
