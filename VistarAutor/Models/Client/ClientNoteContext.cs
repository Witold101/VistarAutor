using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Client
{
    public class ClientNoteContext:DbContext
    {
        public ClientNoteContext() : base("VistarDb") { }
        public DbSet<ClientNote> ClientNotes { get; set; }

        public System.Data.Entity.DbSet<VistarAutor.Models.Client.Client> Clients { get; set; }
    }
}