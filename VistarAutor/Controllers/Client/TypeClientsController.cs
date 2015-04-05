using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models.Client;

namespace VistarAutor.Controllers.Client
{
    public class TypeClientsController : Controller
    {
        private TypeClientContext db = new TypeClientContext();

        // GET: TypeClients
        public ActionResult Index()
        {
            return View(db.TypeClients.ToList());
        }

        // GET: TypeClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeClients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TypeClient typeClient)
        {
            if (ModelState.IsValid)
            {
                db.TypeClients.Add(typeClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeClient);
        }

        // GET: TypeClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeClient typeClient = db.TypeClients.Find(id);
            if (typeClient == null)
            {
                return HttpNotFound();
            }
            return View(typeClient);
        }

        // POST: TypeClients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TypeClient typeClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeClient);
        }

        // GET: TypeClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeClient typeClient = db.TypeClients.Find(id);
            if (typeClient == null)
            {
                return HttpNotFound();
            }
            return View(typeClient);
        }

        // POST: TypeClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeClient typeClient = db.TypeClients.Find(id);
            db.TypeClients.Remove(typeClient);
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
