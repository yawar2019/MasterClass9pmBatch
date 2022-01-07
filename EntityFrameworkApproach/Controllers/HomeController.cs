using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkApproach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDataExample()
        {
            //ViewData["St1"] = "James";
            ViewBag.st2 = "HelloDoc";
            // return View();
            //TempData["s3"]="vikas";
           return View();
        }

        public ActionResult ViewDataExample2()
        {
            //string result = ViewData["St1"].ToString();
            //string result2 = ViewBag.st2;
            //Keep()  //Peek
            //string value = Convert.ToString(TempData["s3"]);
            // TempData.Keep();
            string value = Convert.ToString(TempData.Peek("s3"));

              return RedirectToAction("ViewDataExample3");

        }

        public ActionResult ViewDataExample3()
        {
             
            // TempData.Keep();
            string value = TempData["s3"].ToString();


            return View();
        }
    }
}