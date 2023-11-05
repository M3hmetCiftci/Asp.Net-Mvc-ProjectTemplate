using CompanyWeb.Models.DBContext;
using CompanyWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace CompanyWeb.Controllers
{
    public class AdminController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var Login = db.Admin.Where(x => x.Email == admin.Email).SingleOrDefault();
            if (Login.Email == admin.Email && Login.Password == admin.Password)
            {
                Session["AdminId"] = Login.Email;
                Session["Email"] = Login.Email;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Username or Password is incorrect";
            return View(admin);
        }

       public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["Eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login","Admin");
          
        }
    }
}