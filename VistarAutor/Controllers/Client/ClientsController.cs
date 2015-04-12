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
    public class ClientsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.Employee).Include(c => c.EnumTypeClient).Include(c => c.Statuse).Include(c => c.TypeClient);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client.Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.EnumTypeClientId = new SelectList(db.EnumTypeClients, "Id", "Name");
            ViewBag.StatuseId = new SelectList(db.Statuses, "Id", "Name");
            ViewBag.TypeClientId = new SelectList(db.TypeClients, "Id", "Name");
            return View();
        }

        // POST: Clients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTimeRegistration,Name,FullName,EnumTypeClientId,EmployeeId,TypeClientId,StatuseId")] Models.Client.Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", client.EmployeeId);
            ViewBag.EnumTypeClientId = new SelectList(db.EnumTypeClients, "Id", "Name", client.EnumTypeClientId);
            ViewBag.StatuseId = new SelectList(db.Statuses, "Id", "Name", client.StatuseId);
            ViewBag.TypeClientId = new SelectList(db.TypeClients, "Id", "Name", client.TypeClientId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client.Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", client.EmployeeId);
            ViewBag.EnumTypeClientId = new SelectList(db.EnumTypeClients, "Id", "Name", client.EnumTypeClientId);
            ViewBag.StatuseId = new SelectList(db.Statuses, "Id", "Name", client.StatuseId);
            ViewBag.TypeClientId = new SelectList(db.TypeClients, "Id", "Name", client.TypeClientId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTimeRegistration,Name,FullName,EnumTypeClientId,EmployeeId,TypeClientId,StatuseId")] Models.Client.Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", client.EmployeeId);
            ViewBag.EnumTypeClientId = new SelectList(db.EnumTypeClients, "Id", "Name", client.EnumTypeClientId);
            ViewBag.StatuseId = new SelectList(db.Statuses, "Id", "Name", client.StatuseId);
            ViewBag.TypeClientId = new SelectList(db.TypeClients, "Id", "Name", client.TypeClientId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client.Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Client.Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
