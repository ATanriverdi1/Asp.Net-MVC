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
    public class SendMessagesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: SendMessages
        [Auth]
        public ActionResult Index()
        {
            return View(db.SendMessage.ToList());
        }

        // GET: SendMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneNumber,Email,Name,Text")] SendMessage sendMessage)
        {
            if (ModelState.IsValid)
            {
                db.SendMessage.Add(sendMessage);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(sendMessage);
        }

        // GET: SendMessages/Delete/5
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendMessage sendMessage = db.SendMessage.Find(id);
            if (sendMessage == null)
            {
                return HttpNotFound();
            }
            return View(sendMessage);
        }

        // POST: SendMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [Auth]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SendMessage sendMessage = db.SendMessage.Find(id);
            db.SendMessage.Remove(sendMessage);
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        [Auth]
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
