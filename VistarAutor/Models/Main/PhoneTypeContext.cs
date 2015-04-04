using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class PhoneTypeContext:DbContext
    {
        public PhoneTypeContext(): base("VistarDb")
        { }
        public DbSet<PhoneType> PhoneTypes { get; set; }
    }
}