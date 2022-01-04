using DatabaseApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseApproach.Controllers
{
    public class NewController : Controller
    {
        // GET: New

        private EmployeeEntities db = new EmployeeEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                return Content("Validated successfully");
            }
            else
            {
                return Content("Validation failed");

            }
        }
        public ActionResult GetHtmlHelperData()
        {
            employeeDetail det = new employeeDetail();
            det.EmpName = "prashant";
            return View(det);
        }

        public ActionResult GetStoreprocData()
        {
            return View(db.sp_employee());
        }


        public ActionResult InsertEmployee()
        {
            return View();

        }

        [HttpPost]
        public ActionResult InsertEmployee(sp_employee_Result sp)
        {
            int i = db.spr_insertEmployee(sp.EmpName, sp.EmpSalary);
            if (i > 0)
            {
                return RedirectToAction("GetStoreprocData");
            }
            return View();

        }
    }
}