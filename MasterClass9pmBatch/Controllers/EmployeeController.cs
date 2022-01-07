using MasterClass9pmBatch.Filters;
using MasterClass9pmBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterClass9pmBatch.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee Fareheen
       

        public string GetId(int? id ,string Name,string designation)
        {
            return "My Employee id "+id+" My Employee Name is "+Name+" Designation is"+designation;
        }
        [CustomFilter]

        public ActionResult GetName()
        {
            ViewBag.Player = "Dhoni";
            return View();
        }

        public ActionResult MySecondView()
        {
            return View();
        }
        public ActionResult GetView()
        {
            return View("MySecondView");
        }
        public ActionResult Getgoogle(int ? id)
        {
            if (id == 1)
            {
                return View("MySecondView");
            }
            else
            {
                return Redirect("http://www.google.com");
            }
        }

        [Route("jhansi/Rani")]
        [Route("jhansi/Raja")]
        [Route("jhansi/MahaRaja")]
        public ActionResult GetAttributeRoutExample()
        {

            return View();
        }


        public ActionResult SendData()
        {
           
            ViewBag.info = "Happy Birthday to you";
            return View();

        }

        public ViewResult SendEmployeeData()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Gaurav";
            emp.EmpSalary = 49383;
            
            return View();
        }

         

    }
}

//yawarali17@gmail.com