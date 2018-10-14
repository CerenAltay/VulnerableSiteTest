using SecureWebsitePractices.Membership;
using SecureWebsitePractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecureWebsitePractices.Controllers
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
    }
}