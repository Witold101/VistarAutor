using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Person
{
    public class PersonStatuseContext:DbContext
    {
        public PersonStatuseContext(): base("VistarDb") { }
        public DbSet<PersonStatuse> PersonStatuses { get; set; }
    }
}