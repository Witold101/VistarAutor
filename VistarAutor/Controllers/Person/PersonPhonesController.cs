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
using VistarAutor.Models.Person;

namespace VistarAutor.Controllers.Person
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class PersonPhonesController : Controller
    {
        private PersonPhoneContext db = new PersonPhoneContext();

        // GET: PersonPhones/Create
        public ActionResult Create(int? id)
        {
            if (id == null && db.MyPersons.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name");
            ViewBag.MyPersonId = id;
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType");
            return View();
        }

        // POST: PersonPhones/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CityCod,NamberPhone,Main,PhoneTypeId,MyPersonId,CountryCodeId")] PersonPhone personPhone)
        {
            if (ModelState.IsValid)
            {
                db.PersonPhones.Add(personPhone);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "MyPersons", new { id = personPhone.MyPersonId });
            }

            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", personPhone.CountryCodeId);
            ViewBag.MyPersonId = personPhone.MyPersonId;
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType", personPhone.PhoneTypeId);
            return View(personPhone);
        }

        // GET: PersonPhones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPhone personPhone = await db.PersonPhones.FindAsync(id);
            if (personPhone == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", personPhone.CountryCodeId);
            ViewBag.MyPersonId = personPhone.MyPersonId;
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType", personPhone.PhoneTypeId);
            return View(personPhone);
        }

        // POST: PersonPhones/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CityCod,NamberPhone,Main,PhoneTypeId,MyPersonId,CountryCodeId")] PersonPhone personPhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personPhone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "MyPersons", new { id = personPhone.MyPersonId });
            }
            ViewBag.CountryCodeId = new SelectList(db.CountryCodes, "Id", "Name", personPhone.CountryCodeId);
            ViewBag.MyPersonId = personPhone.MyPersonId;
            ViewBag.PhoneTypeId = new SelectList(db.PhoneTypes, "Id", "NameType", personPhone.PhoneTypeId);
            return View(personPhone);
        }

        // GET: PersonPhones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPhone personPhone = await db.PersonPhones.FindAsync(id);
            if (personPhone == null)
            {
                return HttpNotFound();
            }
            return View(personPhone);
        }

        // POST: PersonPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PersonPhone personPhone = await db.PersonPhones.FindAsync(id);
            int temp = personPhone.MyPersonId;
            db.PersonPhones.Remove(personPhone);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", "MyPersons", new { id = temp });
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
