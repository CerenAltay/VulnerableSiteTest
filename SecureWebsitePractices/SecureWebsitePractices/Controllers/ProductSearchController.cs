using SecureWebsitePractices.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult Index(string id)
        {
            var model = new ProductModel();
            model.ProductList = GetProducts(id);
            return View("ProductSearch", model);
        }

        public List<ProductModel> GetProducts(string prodID)
        {
            var result = new List<ProductModel>();

            var sqlString = "SELECT * FROM DIMProduct WHERE ProductKey = " + prodID;
            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProductModel Products = new ProductModel();

                        Products.ProductKey = reader.GetInt32(0);
                        Products.ProductAlternateKey = reader.GetString(1);
                        Products.ProductName = reader.GetString(5);
                        Products.StockLevel = reader.GetInt16(11);

                        result.Add(Products);
                    }
                }


                // grdProducts.DataSource = command.ExecuteReader(); 
                // grdProducts.DataBind();
            }
            return result;
        }
    }


}