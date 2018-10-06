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
            var secretCookie = new HttpCookie("SecretCookie")
            {
                Value = "Shhh.... it's a secret!",
                Expires = DateTime.Now.AddYears(1)
            };
            Response.Cookies.Add(secretCookie);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?q=" + SearchTerm.Text);
        }
    
    }
}