using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Person
{
    public class PersonMailContext:DbContext
    {
        public PersonMailContext() : base("VistarDb") { }
        public DbSet<PersonMail> PersonMails { get; set; }

        public DbSet<MyPerson> MyPersons { get; set; } 
    }
}