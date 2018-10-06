using Microsoft.ApplicationInsights.Extensibility.Implementation;
using SecureWebsitePractices2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using UserContext = SecureWebsitePractices2.Models.UserContext;

namespace SecureWebsitePractices2.Controllers
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
                Address = profile.Address,
                BirthDate = profile.BirthDate.ToString("d MMM yyyy"),
                TaxFileNumber = profile.NINumber
            },
              JsonRequestBehavior.AllowGet);
        }
    }
}
