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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel reg)
        {
            return View();
        }
        public ActionResult GetHtmlHelperData()
        {
            employeeDetail det = new employeeDetail();
            det.EmpName = "prashant";
            return View(det);
        }
    }
}