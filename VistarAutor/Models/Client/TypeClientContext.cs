using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Client
{
    public class TypeClientContext:DbContext
    {
        public TypeClientContext(): base("VistarDb") { }
        public DbSet<TypeClient> TypeClients { get; set; }
    }
}