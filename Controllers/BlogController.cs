using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CompanyWeb.Models.DBContext;
using CompanyWeb.Models.Model;

namespace CompanyWeb.Controllers
{
    public class BlogController : Controller
    {
        private CompanyDBContext db = new CompanyDBContext();

        // GET: Blog
        public ActionResult Index()
        {
            return View(db.Blog.ToList());
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog , HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                if (ImgURL != null)
                {
                    WebImage img = new WebImage(ImgURL.InputStream);
                    FileInfo ImgInfo = new FileInfo(ImgURL.FileName);
                    string ImgName = Guid.NewGuid().ToString() + ImgInfo.Extension;
                    img.Resize(1366, 800);
                    img.Save("~/Uploads/Blog/" + ImgName);
                    blog.BlogImg = "/Uploads/Blog/" + ImgName;
                }
                db. Blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            var blog = db.Blog.Where(x => x.BlogId == id).SingleOrDefault();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id , Blog blog,HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                var I = db.Blog.Where(x => x.BlogId == id).SingleOrDefault();
                if (ImgURL != null)
                {
                    WebImage img = new WebImage(ImgURL.InputStream);
                    FileInfo ImgInfo = new FileInfo(ImgURL.FileName);
                    string ImgName = Guid.NewGuid().ToString() + ImgInfo.Extension;
                    img.Resize(1366, 800);
                    img.Save("~/Uploads/Blog/" + ImgInfo);
                    I.BlogImg = "/Uploads/Blog/" + ImgInfo;
                }
                I.Title= blog.Title;
                I.ExPlanation= blog.ExPlanation;
                I.history= blog.history;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
        public ActionResult Delete(int id)
        {
            var d = db.Blog.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            db.Blog.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
