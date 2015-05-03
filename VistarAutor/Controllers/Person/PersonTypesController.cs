using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models.Person;

namespace VistarAutor.Controllers.Person
{
    public class PersonTypesController : Controller
    {
        private PersonTypeContext db = new PersonTypeContext();

        // GET: PersonTypes
        public ActionResult Index()
        {
            return View(db.PersonTypes.ToList());
        }

        // GET: PersonTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PersonType personType)
        {
            if (ModelState.IsValid)
            {
                db.PersonTypes.Add(personType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personType);
        }

        // GET: PersonTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonType personType = db.PersonTypes.Find(id);
            if (personType == null)
            {
                return HttpNotFound();
            }
            return View(personType);
        }

        // POST: PersonTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PersonType personType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personType);
        }

        // GET: PersonTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonType personType = db.PersonTypes.Find(id);
            if (personType == null)
            {
                return HttpNotFound();
            }
            return View(personType);
        }

        // POST: PersonTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonType personType = db.PersonTypes.Find(id);
            db.PersonTypes.Remove(personType);
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
