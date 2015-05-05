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
    public class ClientAddressesController : Controller
    {
        private ClientAddresseContext db = new ClientAddresseContext();

        // GET: ClientAddresses/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.ClientId = id;
                ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name");
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: ClientAddresses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CountryCodeId,City,Addresse,PostCode,ClientId,Main")] ClientAddresse clientAddresse)
        {
            if (ModelState.IsValid)
            {
                db.ClientAddresses.Add(clientAddresse);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientAddresse.ClientId });
            }

            ViewBag.ClientId = clientAddresse.ClientId;
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", clientAddresse.CountryCodeId);
            return View(clientAddresse);
        }

        // GET: ClientAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAddresse clientAddresse = await db.ClientAddresses.FindAsync(id);
            if (clientAddresse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = clientAddresse.ClientId;
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", clientAddresse.CountryCodeId);
            return View(clientAddresse);
        }

        // POST: ClientAddresses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CountryCodeId,City,Addresse,PostCode,ClientId,Main")] ClientAddresse clientAddresse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientAddresse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientAddresse.ClientId });
            }
            ViewBag.ClientId = clientAddresse.ClientId;
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", clientAddresse.CountryCodeId);
            return View(clientAddresse);
        }

        // GET: ClientAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAddresse clientAddresse = await db.ClientAddresses.FindAsync(id);
            if (clientAddresse == null)
            {
                return HttpNotFound();
            }
            return View(clientAddresse);
        }

        // POST: ClientAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientAddresse clientAddresse = await db.ClientAddresses.FindAsync(id);
            int? tempId = clientAddresse.ClientId;
            db.ClientAddresses.Remove(clientAddresse);
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
