using MasterClass9pmBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMaster2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.info = MyLogic();
            return View();
        }

       
        private string MyLogic()
        {
            return "this is my logic";
        }

        public ActionResult SendDataMethod()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Sai";
            emp.EmpSalary = 34331;

            ViewBag.empdetail = emp;

            return View();
        }

        public ActionResult SendMultipleDataMethod()
        {
            List<EmployeeModel> listemp = new List<EmployeeModel>();
             

            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Sai";
            emp.EmpSalary = 34331;


            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Jagdish";
            emp1.EmpSalary = 44331;


            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 3;
            emp2.EmpName = "Gaurav";
            emp2.EmpSalary = 54331;


            listemp.Add(emp);
            listemp.Add(emp1);
            listemp.Add(emp2);

            ViewBag.empdetail = listemp;

            return View();
        }

        public ActionResult SendDataMethodUsingModel()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Sai";
            emp.EmpSalary = 34331;

            //object model = emp;
            

            return View(emp);
        }


        public ActionResult SendMultipleDataMethod2()
        {
            List<EmployeeModel> listemp = new List<EmployeeModel>();


            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Sai";
            emp.EmpSalary = 34331;


            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Jagdish";
            emp1.EmpSalary = 44331;


            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 3;
            emp2.EmpName = "Gaurav";
            emp2.EmpSalary = 54331;


            listemp.Add(emp);
            listemp.Add(emp1);
            listemp.Add(emp2);

            

            return View(listemp);
        }

    }
}