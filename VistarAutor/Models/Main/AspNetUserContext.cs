using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class AspNetUserContext:DbContext
    {
        public AspNetUserContext(): base("VistarDb")
        { }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}