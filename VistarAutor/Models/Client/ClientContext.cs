using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Client
{
    public class ClientContext:DbContext
    {
        public ClientContext() : base("VistarDb") { }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EnumTypeClient> EnumTypeClients { get; set; }

        public DbSet<Statuse> Statuses { get; set; }

        public DbSet<TypeClient> TypeClients { get; set; }
    }
}