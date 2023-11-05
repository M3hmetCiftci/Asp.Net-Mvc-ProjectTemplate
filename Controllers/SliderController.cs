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
    public class SliderController : Controller
    {
        private CompanyDBContext db = new CompanyDBContext();

        // GET: Slider
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Slider/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider, HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                if (ImgURL!=null)
                {
                    WebImage img = new WebImage(ImgURL.InputStream);
                    FileInfo ImgInfo = new FileInfo(ImgURL.FileName);
                    string ImgName = Guid.NewGuid().ToString() + ImgInfo.Extension;
                    img.Resize(1366, 800);
                    img.Save("~/Uploads/Slider/" + ImgName);
                    slider.ImgURL = "/Uploads/Slider/" + ImgName;
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

     
        public ActionResult Edit(int id)
        {
            var Slider = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();        
            return View(Slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Slider slider,HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                var I = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();
                if (ImgURL!=null)
                {
                    WebImage img = new WebImage(ImgURL.InputStream);
                    FileInfo ImgInfo = new FileInfo(ImgURL.FileName);
                    string ImgName = Guid.NewGuid().ToString() + ImgInfo.Extension;
                    img.Resize(1366, 800);
                    img.Save("~/Uploads/Slider/" + ImgInfo);
                    I.ImgURL = "/Uploads/Slider/" + ImgInfo;
                }
                I.Titlered = slider.Titlered;
                I.Titlewhite = slider.Titlewhite;
                I.Explanation = slider.Explanation;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            db.Slider.Remove(slider);
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
