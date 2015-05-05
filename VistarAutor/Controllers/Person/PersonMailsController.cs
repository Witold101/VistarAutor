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
    public class PersonMailsController : Controller
    {
        private PersonMailContext db = new PersonMailContext();

        // GET: PersonMails/Create
        public ActionResult Create(int? id)
        {
            if (id == null && db.MyPersons.Find(id) == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = id;
            return View();
        }

        // POST: PersonMails/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Mail,Main,MyPersonId")] PersonMail personMail)
        {
            if (ModelState.IsValid)
            {
                db.PersonMails.Add(personMail);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "MyPersons", new { id = personMail.MyPersonId });
            }
            ViewBag.PersonId = personMail.MyPersonId;
            return View(personMail);
        }

        // GET: PersonMails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonMail personMail = await db.PersonMails.FindAsync(id);
            if (personMail == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = personMail.MyPersonId;
            return View(personMail);
        }

        // POST: PersonMails/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Mail,Main,MyPersonId")] PersonMail personMail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personMail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "MyPersons", new { id = personMail.MyPersonId });
            }
            ViewBag.PersonId = personMail.MyPersonId;
            return View(personMail);
        }

        // GET: PersonMails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonMail personMail = await db.PersonMails.FindAsync(id);
            if (personMail == null)
            {
                return HttpNotFound();
            }
            return View(personMail);
        }

        // POST: PersonMails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PersonMail personMail = await db.PersonMails.FindAsync(id);
            int temp = personMail.MyPersonId;
            db.PersonMails.Remove(personMail);
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
