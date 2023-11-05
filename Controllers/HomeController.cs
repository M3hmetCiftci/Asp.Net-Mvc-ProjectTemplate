using CompanyWeb.Models.DBContext;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CompanyWeb.Controllers
{
    
    public class HomeController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Price()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View(db.Communications.SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Contact(string Name=null, string Email=null, string Subject=null, string Message=null )
        {
            if (Name!=null && Email!=null ) 
            {
                WebMail.SmtpServer = "?";
                WebMail.EnableSsl = true;
                WebMail.SmtpPort = 587;
                WebMail.UserName = "?";
                WebMail.Password="?";
                WebMail.Send("",Subject,Email+"<br/>"+Message);
                ViewBag.Warning="Message sent";
            }
            else
            {
                ViewBag.Warning = "Message not sent";
            }
            return View();
        }
        public ActionResult TopBarPartial()
        {
            return View();
        }
        public ActionResult AboutPartial()
        {
            return View();
        }
        public ActionResult ServicePartial()
        {
            return View();
        }
        public ActionResult PricePartial()
        {
            return View();
        }
        public ActionResult LocationPartial()
        {
            return View();
        }
        public ActionResult TeamPartial()
        {
            return View();
        }
        public ActionResult TestimonialPartial()
        {
            return View();
        }
        public ActionResult BlogPartial()
        {
            return View();
        }
    }
}
