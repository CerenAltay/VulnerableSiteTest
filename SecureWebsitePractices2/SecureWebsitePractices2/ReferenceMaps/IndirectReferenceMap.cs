using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SecureWebsitePractices2.ReferenceMaps
{
    public static class IndirectReferenceMap
    {
        public static string GetIndirectReference(this string directRef)
        {
            try
            {
                var map = (Dictionary<string, string>)HttpContext.Current.Session["Map"];
                return map == null ? AddDirectReference(directRef) : map[directRef];
            }
            catch(Exception e) {
                return null;
            }
        }

        public static string GetDirectReference(this string indirectRef)
        {
            try
            {
                var map = HttpContext.Current.Session["Map"];

                if (map == null)
                {
                    throw new ApplicationException("No map found");
                }

                return ((Dictionary<string, string>)map)[indirectRef];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static string AddDirectReference(string directRef)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[32];
            rng.GetBytes(buff);

            var indirectRef = HttpServerUtility.UrlTokenEncode(buff);

            var map = new Dictionary<string, string>
        {
          {directRef, indirectRef},
          {indirectRef, directRef}
        };

            HttpContext.Current.Session["Map"] = map;
            return indirectRef;
        }
    }
}
