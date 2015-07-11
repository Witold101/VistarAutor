using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VistarAutor.Models;
using VistarAutor.Models.Client;
using VistarAutor.Models.Main;
using VistarAutor.Models.Person;

namespace VistarAutor.Controllers.Client
{
    [Authorize(Roles = GlobalStrings.SUPER_ADMIN)]
    public class ClientsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Clients
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(db.GetClients().OrderBy(c=>c.Name));
            }
            else
            {
                switch (id)
                {
                    case 1:
                        return View(db.GetClients().OrderBy(c=>c.Name));
                    case 2:
                        return View(db.GetClients().OrderBy(c => c.TypeClient.Name));
                    case 3:
                        return View(db.GetClients().OrderBy(c => c.Employee.Name));
                    default:
                        return View(db.GetClients().OrderBy(c=>c.Name));
                }
            }
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client.Client client = db.GetClient(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            foreach (MyPerson person in client.MyPersons)
            {
                person.PersonPhones = db.PersonPhones
                    .Include(c=>c.CountryCode)
                    .Include(c=>c.MyPerson)
                    .Include(c=>c.PhoneType)
                    .ToList()
                    .FindAll(c=>c.MyPersonId==person.Id);
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

        public ActionResult List(int? id)
        {
            Models.Client.Client client;
            List<Models.Client.Client> clients;
            if (id == null || id <= 0)
            {
                client = db.GetClients().OrderBy(c => c.Name).ToList().First();
                clients = db.GetClients().OrderBy(c => c.Name).ToList();
            }
            else
            {
                clients = db.GetClients().OrderBy(c=>c.Name).ToList();
                client = clients.Find(c=>c.Id==id);
            }
            if (client == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foreach (Models.Client.Client rezClient in clients)
            {
                rezClient.MyPersons = db.MyPersons
                    .Include(c => c.PersonMails)
                    .Include(c => c.PersonPhones)
                    .ToList().FindAll(c => c.ClientId == rezClient.Id);

                foreach (MyPerson rezMyPerson in rezClient.MyPersons)
                {

                    rezMyPerson.PersonPhones = db.PersonPhones
                    .Include(c => c.CountryCode)
                    .Include(c => c.MyPerson)
                    .Include(c => c.PhoneType)
                    .ToList()
                    .FindAll(c => c.MyPersonId == rezMyPerson.Id);
                }
            }
            ViewBag.Notes = client.ClientNotes.OrderByDescending(c => c.DateTime).ToList();
        
            ViewBag.ClientRez = client;
            ViewBag.ClientId = id;
            return View(clients);
        }

        public ActionResult PartialClient(int? id)
        {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
            Models.Client.Client client = db.GetClient(id);
            if (client == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client.ClientNotes = client.ClientNotes.OrderByDescending(c => c.DateTime).ToList();
            ViewBag.Notes = client.ClientNotes;
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> PartialClient([Bind(Include = "Id,DateTime,Text,ClientId")] ClientNote clientNote)
        {
            if (clientNote.Text.Trim() != "")
            {
                db.ClientNotes.Add(clientNote);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("PartialClient", new {id = clientNote.ClientId});
        }

        public ActionResult PartialDellPerson(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPerson person = db.MyPersons.Find(id);
            person.Client = db.Clients.Find(person.ClientId);
            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return PartialView(person);
        }

        // POST: MyPersons/Delete/5
        [HttpPost]
        public async Task<ActionResult> PartialDellPerson([Bind(Include = "Id")]int id)
        {
            MyPerson myPerson = await db.MyPersons.FindAsync(id);
            int tempId = myPerson.ClientId;
            db.MyPersons.Remove(myPerson);
            await db.SaveChangesAsync();
            return RedirectToAction("PartialClientEdit", new { id = tempId });
        }



        [HttpPost]
        public async Task<ActionResult> PartialClientEdit([Bind(Include = "Id,Name,ClientId,Birthday,Department,Position,Note")] MyPerson person)
        {
            db.MyPersons.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("PartialClientEdit", new { id = person.ClientId });
        }

        public ActionResult PartialClientEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client.Client client = db.GetClient(id);
            if (client == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             client.MyPersons = db.MyPersons
                    .Include(c => c.PersonMails)
                    .Include(c => c.PersonPhones)
                    .ToList().FindAll(c => c.ClientId == client.Id);

                foreach (MyPerson rezMyPerson in client.MyPersons)
                {

                    rezMyPerson.PersonPhones = db.PersonPhones
                    .Include(c => c.CountryCode)
                    .Include(c => c.MyPerson)
                    .Include(c => c.PhoneType)
                    .ToList()
                    .FindAll(c => c.MyPersonId == rezMyPerson.Id);
                }
            
            ViewBag.ClientRez = client;
            return PartialView();
        }

        [HttpPost]
        public ActionResult PartialEditPerson([Bind(Include = "Id")] int? id)
        {
            id = 17;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPerson person = db.MyPersons.Find(id);
            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person.PersonPhones = db.PersonPhones
                   .Include(c => c.CountryCode)
                   .Include(c => c.PhoneType)
                   .ToList().FindAll(c => c.MyPersonId == person.Id);
            person.PersonMails = db.PersonMails
                   .ToList().FindAll(c => c.MyPersonId == person.Id);
            return PartialView(person);
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
