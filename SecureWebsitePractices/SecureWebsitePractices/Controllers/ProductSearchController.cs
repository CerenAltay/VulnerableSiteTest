using SecureWebsitePractices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SecureWebsitePractices.Controllers
{
    public class ProductSearchController : Controller
    {
        // GET: ProductSearch
        public ActionResult Index()
        {
            var products = GetProducts();
            return View("ProductSearch");
        }

        public List<ProductModel> GetProducts()
        {
            var result = new List<ProductModel>();

            var prodID = 1;//Request.QueryString["ProductKey"];
            var sqlString = "SELECT * FROM DIMProduct WHERE ProductKey = " + prodID;
            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);
                command.Connection.Open();
                // grdProducts.DataSource = command.ExecuteReader(); 
                // grdProducts.DataBind();
            }

            return result;
        }
    }


}