using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using ActionResultExample.Models;
using ActionResultExample.CalculatorServiceReference;
using ActionResultExample;

namespace ActionResultExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }


        public ContentResult GetDifferentContent(int? id)
        {
            if (id == 1)
            {

                return Content("Hello World");
            }

            else if (id == 2)
            {
                return Content("<p style=color:red>Hello World</p>");
            }

            else
            {
                return Content("<script>alert('Hi')</script>");
            }
        }





        public RedirectToRouteResult RedirectMetoRoute()

        {

            return RedirectToRoute("Default2");

        }




        public RedirectToRouteResult RedirectMetoRoute2()

        {

            return RedirectToAction("index", "Default");

        }

        //jumping from OneAction Method to Another we canuse RedirectToAction



        public ActionResult GetDataFromDapper()
        {
            SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true ");
            var result = con.Query<EmployeeModel>("Select EmpId,EmpName,EmpSalary from [Employee].[dbo].[employeeDetails]");


            return View();


        }


        public ActionResult GetCalculatorService()
        {
            CalculatorServiceSoapClient obj = new CalculatorServiceSoapClient();
            string result = obj.AddCalculator(12, 20, "+");
            return Content(result);
        }
        public ActionResult GetWCFService()
        {
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client("WSHttpBinding_IService1");
            int result = obj.Add(12, 20);
            ServiceReference1.Service1Client obj1 = new ServiceReference1.Service1Client("NetTcpBinding_IService1");
            int result1 = obj1.Add(42, 20);

            return Content(result.ToString()+ result1.ToString());
        }


    }
}