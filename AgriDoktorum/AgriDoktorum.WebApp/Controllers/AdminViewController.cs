using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgriDoktorum.WebApp.Filter;
using AgriDoktorum.WebApp.Models.EntityDb;

namespace AgriDoktorum.WebApp.Controllers
{
    [Auth]
    public class AdminViewController : Controller
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        // GET: AboutView
        public ActionResult AboutView()
        {
            return View(_context.About.ToList());
        }

        //GET : ContactView
        public ActionResult ContactView()
        {
            return View(_context.Contact);
        }

        //GET : BlogView
        public ActionResult BlogView()
        {
            return View(_context.Blogs);
        }

        //GET : TreatmentView
        public ActionResult TreatmentView()
        {
            return View(_context.Treatments);
        }

        //GET : GalleryView
        public ActionResult GalleryView()
        {
            return View(_context.Galleries);
        }
    }
}