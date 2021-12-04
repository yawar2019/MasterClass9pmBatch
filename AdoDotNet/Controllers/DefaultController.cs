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
    }
}

//Connection Oriented           Disconnected Oriented Architecture 

//    1)sqlcommand                         1)sqldataAdapter

//     2)Datareader                             Dataset

    