using MasterClass9pmBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMaster2.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index(EmployeeModel emp1)
        {
            return Content("I am New Controller");
        }
    }
}