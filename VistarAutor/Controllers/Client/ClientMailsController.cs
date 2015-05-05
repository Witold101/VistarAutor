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
using VistarAutor.Models.Client;

namespace VistarAutor.Controllers.Client
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class ClientMailsController : Controller
    {
        private ClientMailContext db = new ClientMailContext();

        // GET: ClientMails/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.ClientId = id;
                return View();
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        // POST: ClientMails/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Mail,ClientId,Main")] ClientMail clientMail)
        {
            if (ModelState.IsValid)
            {
                db.ClientMails.Add(clientMail);
                await db.SaveChangesAsync();
                return RedirectToAction("Details","Clients",new {id=clientMail.ClientId});
            }

            ViewBag.ClientId = clientMail.ClientId;
            return View(clientMail);
        }

        // GET: ClientMails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMail clientMail = await db.ClientMails.FindAsync(id);
            if (clientMail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = clientMail.ClientId;
            return View(clientMail);
        }

        // POST: ClientMails/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Mail,ClientId,Main")] ClientMail clientMail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientMail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientMail.ClientId });
            }
            ViewBag.ClientId = clientMail.ClientId;
            return View(clientMail);
        }

        // GET: ClientMails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMail clientMail = await db.ClientMails.FindAsync(id);
            if (clientMail == null)
            {
                return HttpNotFound();
            }
            return View(clientMail);
        }

        // POST: ClientMails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientMail clientMail = await db.ClientMails.FindAsync(id);
            int? tempId = clientMail.ClientId;
            db.ClientMails.Remove(clientMail);
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
