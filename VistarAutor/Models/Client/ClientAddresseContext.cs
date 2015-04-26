using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Client
{
    public class ClientAddresseContext:DbContext
    {
        public ClientAddresseContext() : base("VistarDb") { }
        public DbSet<ClientAddresse> ClientAddresses { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CountryCode> CountryCodes { get; set; }
    }
}