using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            db.EmployeeModels.Add(emp);//insert query
            db.SaveChanges();//Execute Query
            return RedirectToAction("Index");
        }

    }
}