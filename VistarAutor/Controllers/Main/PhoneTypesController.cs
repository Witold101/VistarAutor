using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models;
using VistarAutor.Models.Main;

namespace VistarAutor.Controllers.Main
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class PhoneTypesController : Controller
    {
        private PhoneTypeContext db = new PhoneTypeContext();

        // GET: PhoneTypes
        public ActionResult Index()
        {
            return View(db.PhoneTypes.ToList());
        }

     
        // GET: PhoneTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameType")] PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                db.PhoneTypes.Add(phoneType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phoneType);
        }

        // GET: PhoneTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return HttpNotFound();
            }
            return View(phoneType);
        }

        // POST: PhoneTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameType")] PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phoneType);
        }

        // GET: PhoneTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return HttpNotFound();
            }
            return View(phoneType);
        }

        // POST: PhoneTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneType phoneType = db.PhoneTypes.Find(id);
            db.PhoneTypes.Remove(phoneType);
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
