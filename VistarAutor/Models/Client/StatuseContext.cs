using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Client
{
    public class StatuseContext:DbContext
    {
        public StatuseContext() : base("VistarDb") { }
        public DbSet<Statuse> Statuses { get; set; }
    }
}