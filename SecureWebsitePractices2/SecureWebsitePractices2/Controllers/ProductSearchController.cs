using SecureWebsitePractices2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SecureWebsitePractices2.Controllers
{
    public class ProductSearchController : Controller
    {


        //--> Original
        // GET: ProductSearch
        //public ActionResult Index(string productid, string name)
        //{
        //    var model = new ProductModel();

        //    if (productid == String.Empty && name == String.Empty || (productid == null && name == null))
        //    {
        //        model.ProductList = GetProductsId("1");
        //    }
        //    if (productid != null && (name == null || name == String.Empty))
        //    {
        //        model.ProductList = GetProductsId(productid);
        //        model.SearchedById = true;
        //        model.ProductKey = productid;
        //    }
        //    else if (name != null)
        //    {
        //        model.SearchedByName = true;
        //        model.ProductName = name;
        //        model.ProductList = GetProductsName(name);
        //    }
        //    else
        //    {
        //        return View("Index", model);

        //    }
        //    return View(model);
        //}

        //--> SQL 4 Entity Framework
        public ActionResult Index(string productid, string name)
        {
            var model = new ProductModel();

            if (productid == String.Empty && name == String.Empty || (productid == null && name == null))
            {
                model.ProductsList = GetProductsId("1");
            }
            if (productid != null && (name == null || name == String.Empty))
            {
                model.ProductsList = GetProductsId(productid);
                model.SearchedById = true;
                model.ProductKey = productid;
            }
            else if (name != null)
            {
                model.SearchedByName = true;
                model.ProductName = name;
                model.ProductList = GetProductsName(name);
            }
            else
            {
                return View("Index", model);

            }
            return View(model);
        }


        public ActionResult SearchValue(string id, string name)
        {
            return RedirectToAction("Index", new { productid = id, name = name });
        }

        //--> original

        //public List<ProductModel> GetProductsId(string prodID)
        //{
        //    var result = new List<ProductModel>();

        //    var sqlString = "SELECT * FROM Product WHERE ProductKey = " + prodID;
        //    var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    using (var conn = new SqlConnection(connString))
        //    {
        //        var command = new SqlCommand(sqlString, conn);
        //        command.Connection.Open();
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {

        //                ProductModel Products = new ProductModel();

        //                Products.ProductKey = reader.GetInt32(0).ToString();
        //                Products.ProductAlternateKey = reader.GetString(1);
        //                Products.ProductName = reader.GetString(5);
        //                Products.StockLevel = reader.GetInt16(9);

        //                result.Add(Products);
        //            }
        //        }
        //    }
        //    return result;
        //}


        //SQL 1 --> Parameterisation
        /*
        public List<ProductModel> GetProductsId(string prodID)
        {
            var result = new List<ProductModel>();

            //added productKey parameter
            string productKey = prodID;
            var sqlString = "SELECT * FROM Product WHERE ProductKey = @ProductKey";

            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);

                //input value assigned to the parameter
                SqlParameter key = command.Parameters.AddWithValue("@ProductKey", productKey);

                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProductModel Products = new ProductModel();

                        Products.ProductKey = reader.GetInt32(0).ToString();
                        Products.ProductAlternateKey = reader.GetString(1);
                        Products.ProductName = reader.GetString(5);
                        Products.StockLevel = reader.GetInt16(9);

                        result.Add(Products);
                    }
                }
            }
            return result;
        }
        */

        //--> SQL 2-Stored Procedures
        /*
        public List<ProductModel> GetProductsId(string prodID)
        {
            var result = new List<ProductModel>();

            // Parameter created
            string productKey = prodID;

            var connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // added stored procedure
            var sqlString = "FetchProducts";

            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);

                //Sql parameter used in SP
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter key = command.Parameters.AddWithValue("@ProductKey", productKey);


                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProductModel Products = new ProductModel();

                        Products.ProductKey = reader.GetInt32(0).ToString();
                        Products.ProductAlternateKey = reader.GetString(1);
                        Products.ProductName = reader.GetString(5);
                        Products.StockLevel = reader.GetInt16(9);

                        result.Add(Products);
                    }
                }
            }
            return result;
        }
        */

        //--> SQL 3 Input validation-type conversion 
        /*
        public List<ProductModel> GetProductsId(string prodID)
        {
            var result = new List<ProductModel>();

            //Input validated by type conversion 
            int productKey;
            if (!int.TryParse(prodID, out productKey))
            {

                throw new ApplicationException("Not a valid input format");
            }

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

                        Products.ProductKey = reader.GetInt32(0).ToString();
                        Products.ProductAlternateKey = reader.GetString(1);
                        Products.ProductName = reader.GetString(5);
                        Products.StockLevel = reader.GetInt16(9);

                        result.Add(Products);
                    }
                }
            }
            return result;
        }
        */

        //--> SQL 4 Entity Framework
        public List<Product> GetProductsId(string prodID)
        {
            var result = new List<Product>();

            ProductModel Products = new ProductModel();

            int id;

            var context = new SecureWebsiteEntities();

            int.TryParse(prodID, out id);


            result = context.Products.Where(x => x.ProductKey == id).ToList();

            //Products.productkey = reader.getint32(0).tostring();
            //Products.productalternatekey = reader.getstring(1);
            //Products.productname = reader.getstring(5);
            //Products.stocklevel = reader.getint16(9);

            //result.add(products);

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
                        Products.ProductKey = reader.GetInt32(0).ToString();
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
