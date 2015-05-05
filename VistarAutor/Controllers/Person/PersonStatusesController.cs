using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models;
using VistarAutor.Models.Person;

namespace VistarAutor.Controllers.Person
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class PersonStatusesController : Controller
    {
        private PersonStatuseContext db = new PersonStatuseContext();

        // GET: PersonStatuses
        public ActionResult Index()
        {
            return View(db.PersonStatuses.ToList());
        }

        // GET: PersonStatuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonStatuses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PersonStatuse personStatuse)
        {
            if (ModelState.IsValid)
            {
                db.PersonStatuses.Add(personStatuse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personStatuse);
        }

        // GET: PersonStatuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonStatuse personStatuse = db.PersonStatuses.Find(id);
            if (personStatuse == null)
            {
                return HttpNotFound();
            }
            return View(personStatuse);
        }

        // POST: PersonStatuses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PersonStatuse personStatuse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personStatuse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personStatuse);
        }

        // GET: PersonStatuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonStatuse personStatuse = db.PersonStatuses.Find(id);
            if (personStatuse == null)
            {
                return HttpNotFound();
            }
            return View(personStatuse);
        }

        // POST: PersonStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonStatuse personStatuse = db.PersonStatuses.Find(id);
            db.PersonStatuses.Remove(personStatuse);
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
    }
}
