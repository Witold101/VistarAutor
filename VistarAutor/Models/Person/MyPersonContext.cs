using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Person
{
    public class MyPersonContext:DbContext
    {
        public MyPersonContext() : base("VistarDb") { }
        public DbSet<MyPerson> MyPersons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<PersonStatuse> PersonStatuses { get; set; }
        public DbSet<Client.Client> Clients { get; set; }
        public DbSet<PersonMail> PersonMails { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }

        public List<MyPerson> GerPersons(int id)
        {
            return MyPersons
                .Include(c => c.Department)
                .Include(c => c.Position)
                .Include(c => c.PersonType)
                .Include(c => c.PersonStatuse)
                .Include(c => c.Client)
                .Include(c => c.PersonMails)
                .Include(c => c.PersonPhones)
                .Where(c => c.ClientId == id)
                .ToList();
        }

        public MyPerson GePerson(int? id)
        {
            MyPerson myPerson= MyPersons
                .Include(c => c.PersonMails)
                .Include(c => c.Department)
                .Include(c => c.Position)
                .Include(c => c.PersonType)
                .Include(c => c.PersonStatuse)
                .Include(c => c.Client)
                .First(c => c.Id == id);
            myPerson.PersonPhones = PersonPhones
                .Include(c => c.CountryCode)
                .Include(c => c.MyPerson)
                .Include(c => c.PhoneType)
                .ToList()
                .FindAll(c => c.MyPersonId == id);
            return myPerson;
        }
    }
}