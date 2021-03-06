using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseApproach.Models;
using System.IO;

namespace DatabaseApproach.Controllers
{
    public class employeeDetailsController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: employeeDetails
        //public ActionResult Index()
        //{
        //    return View(db.sp_employee().ToList());
        //}
        public ActionResult Index()
        {
            var empdept = (from e in db.employeeDetails
                           join
                          d in db.Departments
                          on
                           e.DeptId equals d.DeptId
                           select new EmpDeptDetails
                           {
                               EmpId = e.EmpId,
                               EmpName = e.EmpName,
                               EmpSalary = e.EmpSalary,
                               DeptName = d.DeptName
                           }).ToList();
            return View(empdept);
        }
        // GET: employeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // GET: employeeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpSalary,DeptId,Address,dob,Status,CreatedBy,MobileNo,Available")] employeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.employeeDetails.Add(employeeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDetail);
        }

        // GET: employeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpSalary,DeptId,Address,dob,Status,CreatedBy,MobileNo,Available")] employeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetail);
        }

        // GET: employeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            db.employeeDetails.Remove(employeeDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult HtmlHelperExample()
        {
            ViewBag.Employee = new SelectList(db.employeeDetails, "EmpId", "EmpName", 59032);
            return View();
        }

        public ActionResult RegistrationForm()
        {
            ViewBag.Employee = new SelectList(db.employeeDetails, "EmpId", "EmpName", 59032);
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationForm(string Fname, string Password, string Gender, string Manager)
        {
            ViewBag.Employee = new SelectList(db.employeeDetails, "EmpId", "EmpName", 59032);
            return View();
        }

        public ActionResult UploadDocument()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDocument(HttpPostedFileBase fileupload)
        {
            string filename = Path.GetFileName(fileupload.FileName);
            string path = Server.MapPath("~/upload");
            fileupload.SaveAs(Path.Combine(path, filename));
            ViewBag.msg = "uploaded successfully";

            return View();
        }



        public JsonResult AddManagerMr(string Name)
        {
            string result = "Mr " + Name;
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}
