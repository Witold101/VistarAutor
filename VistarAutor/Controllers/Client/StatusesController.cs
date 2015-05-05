using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models;
using VistarAutor.Models.Client;

namespace VistarAutor.Controllers.Client
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class StatusesController : Controller
    {
        private StatuseContext db = new StatuseContext();

        // GET: Statuses
        public ActionResult Index()
        {
            return View(db.Statuses.ToList());
        }

        // GET: Statuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statuses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Statuse statuse)
        {
            if (ModelState.IsValid)
            {
                db.Statuses.Add(statuse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statuse);
        }

        // GET: Statuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statuse statuse = db.Statuses.Find(id);
            if (statuse == null)
            {
                return HttpNotFound();
            }
            return View(statuse);
        }

        // POST: Statuses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Statuse statuse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statuse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statuse);
        }

        // GET: Statuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statuse statuse = db.Statuses.Find(id);
            if (statuse == null)
            {
                return HttpNotFound();
            }
            return View(statuse);
        }

        // POST: Statuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statuse statuse = db.Statuses.Find(id);
            db.Statuses.Remove(statuse);
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
