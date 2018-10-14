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

            Session["Username"] = model.Username;
            ViewBag.Username = model.Username;
            return View();
        }

        public ActionResult About(ProfileModel model)
        {
            Session["Username"] = model.UserName;
            using (UserContext context = new UserContext())
            {
                model = context.Profiles.SingleOrDefault(x => x.UserName == model.UserName);
            }

            if (model == null)
            {
                throw new ApplicationException("Profile does not exist");
            }

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}