using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using Project1.Models;


namespace Project1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        
        public ViewResult Index()
        {
            return View();
        } 
        //Action method for Front page to select a button
     public ActionResult About (String choice)
        {
            if (choice.Equals("Customer"))
            {
                ViewBag.Message = "Application Page.CUSTOMER" + choice;
                return View("Index");
            }
            else
            {
                ViewBag.Message = "Your application description page. ADMIN" + choice;
                return RedirectToRoute(new { controller = "Admin", action = "Index" });

            }

            }
        

     public ViewResult FinalOrder(Class1 o)
        {
            //establishing the DB connection for the first time. 
            Console.Write("Final Order Controller called.");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Ammu\\documents\\visual studio 2017\\Projects\\Project1\\Project1\\App_Data\\Database.mdf';Integrated Security=True";
            SqlConnection sqlconn = new SqlConnection(connectionString);
            String sql = "INSERT INTO IphoneOrderTable(Name,MiniPhone,XLPhone,GlassPhone,TotalPrice) VALUES (@value1,@value2,@value3,@value4,@value5)";
            sqlconn.Open();
            SqlCommand sqlc = new SqlCommand(sql, sqlconn);
            Console.Write("Final Order Controller called.");
            sqlc.Parameters.Add("@value1", SqlDbType.VarChar, 20).Value = o.Name;
            sqlc.Parameters.Add("@value2", SqlDbType.Int).Value = o.MiniPhone;
            sqlc.Parameters.Add("@value3", SqlDbType.Int).Value = o.XLPhone;
            sqlc.Parameters.Add("@value4", SqlDbType.Int).Value = o.GlassPhone;
            sqlc.Parameters.Add("@value5", SqlDbType.Int).Value = o.TotalPrice;
            sqlc.CommandType = CommandType.Text;
            sqlc.ExecuteNonQuery();
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


