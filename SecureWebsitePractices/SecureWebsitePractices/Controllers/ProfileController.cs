using Microsoft.ApplicationInsights.Extensibility.Implementation;
using SecureWebsitePractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using UserContext = SecureWebsitePractices.Models.UserContext;

namespace SecureWebsitePractices.Controllers
{
    public class ProfileController : Controller
    {
       
        public ActionResult Index(string userName, ProfileModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
               ViewBag.Username = Session["Username"];
                return View();
            }

            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
                ProfileModel profile = new ProfileModel();

                using (UserContext context = new UserContext())
                {
                    profile = context.Profiles.SingleOrDefault(x => x.UserName == userName);
                }

                if (profile == null)
                {
                    throw new ApplicationException("Profile does not exist");
                }

                return View("Profile");
            }

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

        // GET: Profile
        public ActionResult GetProfile(string userName)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    throw new ApplicationException("User not authenticated");
            //}

            ProfileModel profile = new ProfileModel();

            using (UserContext context = new UserContext())
            {
                profile = context.Profiles.SingleOrDefault(x => x.UserName == userName);
            }

            if (profile == null)
            {
                throw new ApplicationException("Profile does not exist");
            }

            return Json(new
            {
                UserName = profile.UserName,
                Name = profile.Name,
                Email = profile.Email,
                Address = profile.Address,
                BirthDate = profile.BirthDate.ToString("dd MM yyyy"),
                NINumber = profile.NINumber
            },
               JsonRequestBehavior.AllowGet);
        }
    }
}
