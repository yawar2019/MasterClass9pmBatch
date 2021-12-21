using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Edit(int? id)
        {
            EmployeeModel emp = db.EmployeeModels.Find(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            db.Entry(emp).State= EntityState.Modified;//update query
            int result=db.SaveChanges();//Execute Query
            if (result > 0)
                return RedirectToAction("Index");
            else
                return View();
        }

        public ActionResult Delete(int? id)
        {
            EmployeeModel emp = db.EmployeeModels.Find(id);
            return View(emp);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            EmployeeModel emp = db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(emp);
            int result = db.SaveChanges();//Execute Query
            if (result > 0)
                return RedirectToAction("Index");
            else
                return View();
        }
    }
}