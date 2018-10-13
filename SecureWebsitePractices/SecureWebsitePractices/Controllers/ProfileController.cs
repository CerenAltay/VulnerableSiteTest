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
        // GET: Profile
        public ActionResult Index(string userName)
        {
            if (!User.Identity.IsAuthenticated)
            {
                throw new ApplicationException("User not authenticated");
            }

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
                Address = profile.Address,
                BirthDate = profile.BirthDate.ToString("dd MM yyyy"),
                NINumber = profile.NINumber
            },
              JsonRequestBehavior.AllowGet);
        }
    }
}
