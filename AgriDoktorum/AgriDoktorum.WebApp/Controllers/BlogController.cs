using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgriDoktorum.WebApp.Filter;
using AgriDoktorum.WebApp.Models.Entity;
using AgriDoktorum.WebApp.Models.EntityDb;
using AgriDoktorum.WebApp.Models.ViewModel.Blog;

namespace AgriDoktorum.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly DatabaseContext db = new DatabaseContext();

        public ActionResult List(int? id, string q)
        {
            IQueryable<Blog> blog = db.Blogs;
            IQueryable<Blog> blogs = blog.OrderByDescending(p => p.ModifiedOn);

            if (id != null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }
            if (string.IsNullOrEmpty(q) == false)
            {
                blogs = blogs.Where(i => i.BlogTittle.Contains(q) || i.BlogDescription.Contains(q));
            }

            return View(blogs.ToList());
        }


        // GET: Blog
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var categories = db.Categories.ToList();

            if (pageSize > 50)
            {
                pageSize = 50;
            }

            IQueryable<Blog> query = db.Blogs;
            IQueryable<Blog> dataQuery = query.OrderByDescending(p => p.ModifiedOn).Skip((page - 1) * pageSize).Take(pageSize);

            int recordCount = query.Count();
            int pageCount = recordCount / pageSize;

            if (recordCount % pageSize > 0)
                pageCount++;

            return View(new BlogPostViewModel { GetBlogs = dataQuery.ToList(), PageCount = pageCount, CurrentPage = page });
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        [Auth]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Auth]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BlogTittle,BlogText,BlogDescription,CategoryId,BlogImage,ModifiedUsername")] Blog blog, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var extension = Path.GetExtension(file.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        var folder = Server.MapPath("/upload/Blog");
                        var randomfilename = Path.GetFileName(file.FileName);
                        var filename = Path.ChangeExtension(randomfilename, ".jpg");

                        blog.BlogImage = filename;

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
                blog.CreatedOn = DateTime.Now;
                blog.ModifiedOn = DateTime.Now;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("BlogView","AdminView");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Auth]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,BlogTittle,BlogText,BlogDescription,CategoryId,ModifiedUsername")] Blog blog, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var extension = Path.GetExtension(file.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        var folder = Server.MapPath("~/upload/Blog");
                        var randomfilename = Path.GetFileName(file.FileName);
                        var filename = Path.ChangeExtension(randomfilename, ".jpg");

                        blog.BlogImage = filename;

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
                blog.CreatedOn = DateTime.Now;
                blog.ModifiedOn = DateTime.Now;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BlogView", "AdminView");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [Auth]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("BlogView", "AdminView");
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
