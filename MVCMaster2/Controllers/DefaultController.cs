using MasterClass9pmBatch.Models;
using MVCMaster2.Models;
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



        public ActionResult SendMultipleDataMethod3()
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

            // ------------------------

            DepartmentModel dept = new DepartmentModel();
            dept.DeptId = 1;
            dept.DeptName = "IT";

            DepartmentModel dept2 = new DepartmentModel();
            dept2.DeptId = 2;
            dept2.DeptName = "Marketing";

            List<DepartmentModel> listdept = new List<DepartmentModel>();
            listdept.Add(dept);
            listdept.Add(dept2);

            EmpDept ed = new EmpDept();
            ed.emp = listemp;
            ed.dept = listdept;

            return View(ed);
        }


        public RedirectResult MulipleOutput()
        {
            return Redirect("http://www.google.com");
        }


        public RedirectResult MulipleOutput1()
        {
            return Redirect("~/Default/MulipleOutput2");
        }


        public ActionResult MulipleOutput2()
        {
            return Content("hello..");
        }

        public FileResult GetmeFile()
        {
            return File("~/Web.config", "text/plain");
        }

        public FileResult GetmeFile2()
        {
            return File("~/Web.config", "application/xml");
        }
        public FileResult GetmeFile3()
        {
            return File("~/ActionResult.pdf", "application/pdf", "Mvc9pmActionResult.pdf");
        }

        public JsonResult Getjsondata()
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


            return Json(listemp,JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult GetPartialView()
        {
            StudentLocationModel std = new StudentLocationModel();
            std.StudentName = "Farheen";
            std.Location = "Kerala";

            StudentLocationModel std1 = new StudentLocationModel();
            std1.StudentName = "Rajeev";
            std1.Location = "Kerala";

            StudentLocationModel std2 = new StudentLocationModel();
            std2.StudentName = "Gaurav";
            std2.Location = "Maharashtra";

            List<StudentLocationModel> stdListobj = new List<StudentLocationModel>();
            stdListobj.Add(std);
            stdListobj.Add(std1);
            stdListobj.Add(std2);

            return PartialView("_StudentPartialView", stdListobj);
        }
    }
}