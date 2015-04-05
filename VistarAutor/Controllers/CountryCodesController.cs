using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models.Main;

namespace VistarAutor.Controllers
{
    public class CountryCodesController : Controller
    {
        private CountryCodeContext db = new CountryCodeContext();

        // GET: CountryCodes
        public ActionResult Index()
        {
            return View(db.CountryCodes.ToList());
        }

       // GET: CountryCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryCodes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name")] CountryCode countryCode)
        {
            if (ModelState.IsValid)
            {
                db.CountryCodes.Add(countryCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryCode);
        }

        // GET: CountryCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryCode countryCode = db.CountryCodes.Find(id);
            if (countryCode == null)
            {
                return HttpNotFound();
            }
            return View(countryCode);
        }

        // POST: CountryCodes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name")] CountryCode countryCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryCode);
        }

        // GET: CountryCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryCode countryCode = db.CountryCodes.Find(id);
            if (countryCode == null)
            {
                return HttpNotFound();
            }
            return View(countryCode);
        }

        // POST: CountryCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryCode countryCode = db.CountryCodes.Find(id);
            db.CountryCodes.Remove(countryCode);
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
