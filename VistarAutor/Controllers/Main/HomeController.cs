using System;
using System.Collections.Generic;
using System.Linq;
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