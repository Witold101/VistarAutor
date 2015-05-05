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
    public class ClientPhonesController : Controller
    {
        private ClientPhoneContext db = new ClientPhoneContext();

        // GET: ClientPhones/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.ClientId = id;
                ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name");
                ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType");
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: ClientPhones/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PhoneTypeId,CountryCodeId,CityCod,NamberPhone,ClientId,Main")] ClientPhone clientPhone)
        {
            if (ModelState.IsValid)
            {
                db.ClientPhones.Add(clientPhone);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientPhone.ClientId });
            }
            ViewBag.ClientId = clientPhone.ClientId;
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", clientPhone.CountryCodeId);
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType", clientPhone.PhoneTypeId);
            return View(clientPhone);
        }

        // GET: ClientPhones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPhone clientPhone = await db.ClientPhones.FindAsync(id);
            if (clientPhone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = clientPhone.ClientId;
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", clientPhone.CountryCodeId);
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType", clientPhone.PhoneTypeId);
            return View(clientPhone);
        }

        // POST: ClientPhones/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PhoneTypeId,CountryCodeId,CityCod,NamberPhone,ClientId,Main")] ClientPhone clientPhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientPhone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { id = clientPhone.ClientId });
            }
            ViewBag.ClientId = clientPhone.ClientId;
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", clientPhone.CountryCodeId);
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType", clientPhone.PhoneTypeId);
            return View(clientPhone);
        }

        // GET: ClientPhones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPhone clientPhone = await db.ClientPhones.FindAsync(id);
            if (clientPhone == null)
            {
                return HttpNotFound();
            }
            return View(clientPhone);
        }

        // POST: ClientPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientPhone clientPhone = await db.ClientPhones.FindAsync(id);
            int? tempId = clientPhone.ClientId;
            db.ClientPhones.Remove(clientPhone);
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
