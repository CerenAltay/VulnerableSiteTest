using Microsoft.ApplicationInsights.Extensibility.Implementation;
using SecureWebsitePractices2.Models;
using SecureWebsitePractices2.ReferenceMaps;
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
        //original
        /*
          // GET: Profile
          public ActionResult Index(string userName)
          {
              if (!User.Identity.IsAuthenticated)
              {
                  throw new ApplicationException("User not authenticated");
              }

              //Access control
              //if (User.Identity.Name != userName)
              //{
              //    throw new ApplicationException("Access not authorised.");
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
                  Address = profile.Address,
                  BirthDate = profile.BirthDate.ToString("dd MM yyyy"),
                  NINumber = profile.NINumber
              },
                JsonRequestBehavior.AllowGet);
          }
      */

        //Authorisation 2-> indirect ref
        public ActionResult Index(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                throw new ApplicationException("User not authenticated");
            }

            var userName = id.GetDirectReference();


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
