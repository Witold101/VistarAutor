using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models;
using VistarAutor.Models.Person;

namespace VistarAutor.Controllers.Person
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class MyPersonsController : Controller
    {
        private MyPersonContext db = new MyPersonContext();

        // GET: MyPersons/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.ClientId = id;
                ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
                ViewBag.PersonStatuseId = new SelectList(db.PersonStatuses, "Id", "Name");
                ViewBag.PersonTypeId = new SelectList(db.PersonTypes, "Id", "Name");
                ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name");
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: MyPersons/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,LastName,PersonNamber,Birthday,Photo,DepartmentId,PositionId,PersonTypeId,PersonStatuseId,ClientId,Note")] MyPerson myPerson)
        {
            if (ModelState.IsValid)
            {
                db.MyPersons.Add(myPerson);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = myPerson.ClientId });
            }

            ViewBag.ClientId = myPerson.ClientId;
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", myPerson.DepartmentId);
            ViewBag.PersonStatuseId = new SelectList(db.PersonStatuses, "Id", "Name", myPerson.PersonStatuseId);
            ViewBag.PersonTypeId = new SelectList(db.PersonTypes, "Id", "Name", myPerson.PersonTypeId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", myPerson.PositionId);
            return View(myPerson);
        }

        // GET: MyPersons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPerson myPerson =  db.GePerson(id);
            if (myPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = myPerson.ClientId;
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", myPerson.DepartmentId);
            ViewBag.PersonStatuseId = new SelectList(db.PersonStatuses, "Id", "Name", myPerson.PersonStatuseId);
            ViewBag.PersonTypeId = new SelectList(db.PersonTypes, "Id", "Name", myPerson.PersonTypeId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", myPerson.PositionId);
            return View(myPerson);
        }

        // POST: MyPersons/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,LastName,PersonNamber,Birthday,Photo,DepartmentId,PositionId,PersonTypeId,PersonStatuseId,ClientId,Note")] MyPerson myPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myPerson).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = myPerson.ClientId });
            }
            ViewBag.ClientId = myPerson.ClientId;
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", myPerson.DepartmentId);
            ViewBag.PersonStatuseId = new SelectList(db.PersonStatuses, "Id", "Name", myPerson.PersonStatuseId);
            ViewBag.PersonTypeId = new SelectList(db.PersonTypes, "Id", "Name", myPerson.PersonTypeId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", myPerson.PositionId);
            return View(myPerson);
        }

        // GET: MyPersons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPerson myPerson = await db.MyPersons.FindAsync(id);
            if (myPerson == null)
            {
                return HttpNotFound();
            }
            return View(myPerson);
        }

        // POST: MyPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MyPerson myPerson = await db.MyPersons.FindAsync(id);
            int? tempId = myPerson.ClientId;
            db.MyPersons.Remove(myPerson);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Clients", new { id = tempId });
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
