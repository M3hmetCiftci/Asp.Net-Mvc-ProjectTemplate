using CompanyWeb.Models.DBContext;
using CompanyWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CompanyWeb.Controllers
{
    public class AboutController : Controller
    {
        private CompanyDBContext db = new CompanyDBContext();
        // GET: About
        public ActionResult Index()
        {
            return View(db.About.ToList());
        }

        public ActionResult Edit(int id)
        {
            var aboutlist = db.About.Where(x => x.AboutId == id).SingleOrDefault();
            return View(aboutlist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, About about, HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                var A = db.About.Where(x => x.AboutId == id).SingleOrDefault();
                if (ImgURL != null)
                {
                    WebImage img = new WebImage(ImgURL.InputStream);
                    FileInfo ImgInfo = new FileInfo(ImgURL.FileName);
                    string ImgName = Guid.NewGuid().ToString() + ImgInfo.Extension;
                    img.Resize(1366, 800);
                    img.Save("~/Uploads/About/" + ImgInfo);
                    A.ImgURL = "/Uploads/About/" + ImgInfo;
                }
                A.TitleRed=about.TitleRed;
                A.TitleWhite=about.TitleWhite;
                A.Tickt1= about.Tickt1;
                A.Tickt2= about.Tickt2;
                A.Tickt3= about.Tickt3;
                A.Tickt4= about.Tickt4; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }
    }
}