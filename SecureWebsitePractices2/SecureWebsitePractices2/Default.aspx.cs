using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureWebsitePractices2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usersCookie = new HttpCookie("UsersCookie")
            {
                Value = "MaryUU608FAFLIBNN9",
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Add(usersCookie);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?q=" + SearchTerm.Text);
        }
    
    }
}