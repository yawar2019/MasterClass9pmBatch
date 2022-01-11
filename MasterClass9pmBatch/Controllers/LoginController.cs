using MasterClass9pmBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MasterClass9pmBatch.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        EmployeeEntities db = new EmployeeEntities();
        public ActionResult Login()
        {
            return View();
        }
        [Authorize(Roles="Admin,Manager")]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles="Manager")]
        public ActionResult ContactUs()
        {
            return View();
        }


        [Authorize(Roles="Admin")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetail usd)
        {
            var user = db.UserDetails.Where(s => s.UserName == usd.UserName 
                                           && s.Password == usd.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(usd.UserName, false);
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [OutputCache(Duration =20,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult GetDataFromCache()
        {
            return View();
        }
    }
}