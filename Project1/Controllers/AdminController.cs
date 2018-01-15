using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;


namespace Project1.Controllers
{
    public class AdminController : Controller
    {
        //Database Connection 
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Ammu\\documents\\visual studio 2017\\Projects\\Project1\\Project1\\App_Data\\Database.mdf';Integrated Security=True";
        //Action Method Named Index for Admin control
        public ActionResult Index()
        {
            DataTable dtb = new DataTable();
            //Establishing the DB connection to retrieve the DB into the view
            SqlConnection sqlconn = new SqlConnection(connectionString); 
            //Opening the connection
            sqlconn.Open();
            //Writing the query
            SqlCommand command = new SqlCommand("Select * from IphoneOrderTable", sqlconn);
            List<Class1> orderList = new List<Class1>();
            SqlDataReader sdr = command.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var Class1 = new Class1();
                    Class1.Name = sdr.GetString(1);
                    Class1.MiniPhone = sdr.GetInt32(2);
                    Class1.XLPhone = sdr.GetInt32(3);
                    Class1.GlassPhone = sdr.GetInt32(4);
                    Class1.TotalPrice = sdr.GetInt32(5);
                    orderList.Add(Class1);
                }
            }
            return View(orderList);
        }
    }
}
