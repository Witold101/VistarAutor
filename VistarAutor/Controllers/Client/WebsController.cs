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
    public class WebsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: Webs/Create
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

        // POST: Webs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ClientId,Main")] Web web)
        {
            if (ModelState.IsValid)
            {
                db.Webs.Add(web);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = web.ClientId });
            }

            ViewBag.ClientId = web.ClientId;
            return View(web);
        }

        // GET: Webs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Web web = await db.Webs.FindAsync(id);
            if (web == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", web.ClientId);
            return View(web);
        }

        // POST: Webs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ClientId,Main")] Web web)
        {
            if (ModelState.IsValid)
            {
                db.Entry(web).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = web.ClientId });
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", web.ClientId);
            return View(web);
        }

        // GET: Webs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Web web = await db.Webs.FindAsync(id);
            if (web == null)
            {
                return HttpNotFound();
            }
            return View(web);
        }

        // POST: Webs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Web web = await db.Webs.FindAsync(id);
            int? tempId = web.ClientId;
            db.Webs.Remove(web);
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
