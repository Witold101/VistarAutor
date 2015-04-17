using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using VistarAutor.Models;
using VistarAutor.Models.Account;
using VistarAutor.Models.Main;

namespace VistarAutor.Controllers
{
    public class HomeController : Controller
    {
        private AspNetRoleContext db = new AspNetRoleContext();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
        public ActionResult Setup()
        {
            return View();
        }

        public ActionResult SetupListEmployee()
        {
            List<Employee> employees = db.GetListEmployees();
            return View(employees);
        }

        [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.GetEmployee(id);
            if (employee != null)
            {
                ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
                ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
                ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", employee.AspNetUserId);
                return View(employee);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        
        [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee([Bind(Include = "Id,Name,LastName,PersonNamber,Birthday,DayOfEmployment,DayOfDismissal,DepartmentId,PositionId,Photo,AspNetUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SetupListEmployee");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", employee.AspNetUserId);
            return View(employee);
        }

        public ActionResult SetupEmployee()
        {
            ApplicationUserManager user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            Employee employee = db.GetEmployee(7);
            // Возвращает имена а не ID ролей
            employee.Roles = user.GetRoles(employee.AspNetUserId).ToList();

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}