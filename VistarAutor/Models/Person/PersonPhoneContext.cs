using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Person
{
    public class PersonPhoneContext:DbContext
    {
        public PersonPhoneContext() : base("VistarDb") { }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<MyPerson> MyPersons { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; } 
    }
}