using CompanyWeb.Models.DBContext;
using CompanyWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;

namespace CompanyWeb.Controllers
{
    public class NewUserController : Controller
    {
        // GET: NewUser
        CompanyDBContext db = new CompanyDBContext();
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public ActionResult Delete(int id)
        {
            var d = db.Admin.Find(id);
            if (d==null)
            {
                return HttpNotFound();
            }
            db.Admin.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}