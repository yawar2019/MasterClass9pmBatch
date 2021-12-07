using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using AdoDotNet.Models;

namespace AdoDotNet.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default 1;Delete from Employee

        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        { 

            return View(db.GetEmployees());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            int result = db.Save(emp);
            if (result > 0)
            {
                return Redirect("~/Default/Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            EmployeeModel emp = db.GetEmployeeById(id);
            return View(emp);
        }


        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
             
            var result = db.Save(emp);
            if (result > 0)
            {
                return Redirect("~/Default/Index");
            }
            return View();


        }//

    }
}

//Connection Oriented           Disconnected Oriented Architecture 

//    1)sqlcommand                         1)sqldataAdapter

//     2)Datareader                             Dataset

    