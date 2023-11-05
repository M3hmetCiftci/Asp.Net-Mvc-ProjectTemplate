using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyWeb.Models.DBContext;
using CompanyWeb.Models.Model;

namespace CompanyWeb.Controllers
{
    public class TobbarController : Controller
    {
        private CompanyDBContext db = new CompanyDBContext();

        // GET: Tobbar
        public ActionResult Index()
        {
            return View(db.Tobbar.ToList());
        }

        // GET: Tobbar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tobbar tobbar = db.Tobbar.Find(id);
            if (tobbar == null)
            {
                return HttpNotFound();
            }
            return View(tobbar);
        }

        // GET: Tobbar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tobbar tobbar = db.Tobbar.Find(id);
            if (tobbar == null)
            {
                return HttpNotFound();
            }
            return View(tobbar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TobbarId,MainTitle,HourTitle,HourExplanation,TelTitle,TelExplanation,MailTitle,MailExplanation")] Tobbar tobbar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tobbar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tobbar);
        }
    }
}
