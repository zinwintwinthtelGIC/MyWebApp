using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Data.SqlClient;




namespace MyWebApp.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationDBContext _db;

        public CustomerController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            string connectionString = "Server=DESKTOP-80368B6\\SQLEXPRESS;Database=web_app;Trusted_Connection=True;MultipleActiveResultSets=True";
            string query = "SELECT * FROM Customer";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
            HttpContext.Session.SetString("DataTableKey", jsonData);
            return View(dataTable);
        }

        public IActionResult SessionTest()
        {
            string jsonData = HttpContext.Session.GetString("DataTableKey");

            DataTable dataTable = new DataTable();
            if (!string.IsNullOrEmpty(jsonData))
            {
                dataTable = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsonData);
            }
            return View(dataTable);
        }
    }

}


