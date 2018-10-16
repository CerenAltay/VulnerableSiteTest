using SecureWebsitePractices2.Membership;
using SecureWebsitePractices2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SecureWebsitePractices2.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Username = Session["Username"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            // Login logic goes here.

            Session["Username"] = model.Email;
            ViewBag.Username = model.Email;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected void AuditEntry(int id, string user, string message, string severity)
        {
            AuditModel audit = new AuditModel();
            using (UserContext context = new UserContext())
            {
                audit.Auditid = id;
                audit.User = user;
                audit.Message = message;
                audit.Severity = severity;

                audit = context.Audits.Add(audit);
                context.SaveChanges();

            }
        }
    }
}