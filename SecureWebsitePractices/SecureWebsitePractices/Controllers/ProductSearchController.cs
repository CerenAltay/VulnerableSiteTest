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
        public ActionResult Index(string id, string name)
        {
            var model = new ProductModel();

            if (id == String.Empty && name == String.Empty || (id == null && name == null))
            {
                model.ProductList = GetProductsId("1");

            }
            if (id != null && (name == null || name == String.Empty))
            {
                model.ProductList = GetProductsId(id);
                model.SearchedById = true;

            }
            if(name != null && (id == null || id == String.Empty))
            {
                model.SearchedByName = true;
                model.ProductName = name;
                model.ProductList = GetProductsName(name);

            }
            else
            {
                return View("Index", model);

            }
            return View("Index", model);
        }

        //[HttpPost]
        //public ActionResult SearchById(string id)
        //{
        //    var model = new ProductModel();

        //    if (id != null)
        //    {
        //        model.ProductList = GetProductsId(id);
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult SearchByName(string name)
        //{
        //    var model = new ProductModel();

        //    if (name != null)
        //    {
        //        model.ProductList = GetProductsName(name);
        //    }

        //    return View(model);
        //}

        public List<ProductModel> GetProductsId(string prodID)
        {
            var result = new List<ProductModel>();

            var sqlString = "SELECT * FROM Product WHERE ProductKey = " + prodID;
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
            }
            return result;
        }

        public List<ProductModel> GetProductsName(string prodName)
        {
            var result = new List<ProductModel>();

            ProductModel Products = new ProductModel();

            Products.Searched = Request.QueryString["prodName"];


            var sqlString = "SELECT * FROM Product";
            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products.ProductKey = reader.GetInt32(0);
                        Products.ProductAlternateKey = reader.GetString(1);
                        Products.ProductName = reader.GetString(5);
                        Products.StockLevel = reader.GetInt16(11);

                        result.Add(Products);
                    }
                }
            }
            //result = Products.Any(m => m.ProductName.Contains("Products.Searched, StringComparison.OrdinalIgnoreCase") >=0);//"SELECT * FROM Product WHERE ProductName = " + Products.Searched;
            return result;
        }
    }


}