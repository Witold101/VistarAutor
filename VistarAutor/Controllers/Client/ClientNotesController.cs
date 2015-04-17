using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models.Client;

namespace VistarAutor.Controllers.Client
{
    public class ClientNotesController : Controller
    {
        private ClientNoteContext db = new ClientNoteContext();
        
        // GET: ClientNotes/Create
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

        // POST: ClientNotes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DateTime,Text,ClientId")] ClientNote clientNote)
        {
            if (ModelState.IsValid)
            {
                db.ClientNotes.Add(clientNote);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientNote.ClientId });
            }

            ViewBag.ClientId =  clientNote.ClientId;
            return View(clientNote);
        }

        // GET: ClientNotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientNote clientNote = await db.ClientNotes.FindAsync(id);
            if (clientNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = clientNote.ClientId;
            return View(clientNote);
        }

        // POST: ClientNotes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DateTime,Text,ClientId")] ClientNote clientNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientNote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientNote.ClientId });
            }
            ViewBag.ClientId = clientNote.ClientId;
            return View(clientNote);
        }

        // GET: ClientNotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientNote clientNote = await db.ClientNotes.FindAsync(id);
            if (clientNote == null)
            {
                return HttpNotFound();
            }
            return View(clientNote);
        }

        // POST: ClientNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientNote clientNote = await db.ClientNotes.FindAsync(id);
            int? tempId = clientNote.ClientId;
            db.ClientNotes.Remove(clientNote);
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
