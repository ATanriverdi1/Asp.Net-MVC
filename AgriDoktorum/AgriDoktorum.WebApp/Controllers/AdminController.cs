using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgriDoktorum.WebApp.BusinessLayer;
using AgriDoktorum.WebApp.Filter;
using AgriDoktorum.WebApp.Models.Entity;
using AgriDoktorum.WebApp.Models.ViewModel.Admin;

namespace AgriDoktorum.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Auth]
        public ActionResult Index()
        {
            return View();
        }

        //GET : Login
        public ActionResult Login()
        {
            return View();
        }

        //POST : Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AdminManager adminManager = new AdminManager();
                BusinessLayerResult<AdUser> layerResult = adminManager.LoginUser(model);

                if (layerResult.ErrorList.Count > 0)
                {
                    layerResult.ErrorList.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }

                Session["user"] = layerResult.Result;
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET : Register
        [Auth]
        public ActionResult Register()
        {
            return View();
        }

        //POST : Register
        [HttpPost]
        [Auth]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var adminManager = new AdminManager();
                BusinessLayerResult<AdUser> uResult = adminManager.RegisterUser(model);

                if (uResult.ErrorList.Count > 0)
                {
                    uResult.ErrorList.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }

                return RedirectToAction("Login");
            }
            return View(model);
        }
        [Auth]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}