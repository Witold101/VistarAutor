using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Person
{
    public class PersonTypeContext:DbContext
    {
        public PersonTypeContext() : base("VistarDb") { }
        public DbSet<PersonType> PersonTypes { get; set; }
    }
}