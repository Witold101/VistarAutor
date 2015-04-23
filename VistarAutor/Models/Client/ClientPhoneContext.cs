using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Client
{
    public class ClientPhoneContext:DbContext
    {
        public ClientPhoneContext() : base("VistarDb") { }
        public DbSet<ClientPhone> ClientPhones { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
    }
}