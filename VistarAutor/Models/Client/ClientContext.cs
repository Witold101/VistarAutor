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
        public DbSet<ClientMail> ClientMails { get; set; }
        public DbSet<Web> Webs { get; set; }
        public DbSet<ClientNote> ClientNotes { get; set; }
        public DbSet<ClientPhone> ClientPhones { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }

        public Client GetClient(int? id)
        {
            if (id != null || Clients.Find(id) != null)
            {
                Client client = new Client();
                List<Client> clients = Clients.Include(p => p.EnumTypeClient)
                    .Include(p => p.Employee)
                    .Include(p => p.TypeClient)
                    .Include(p=>p.Statuse)
                    .Include(p=>p.ClientPhones)
                    .ToList();
                client=clients.Find(a => a.Id == id);
                client.ClientMails = 
                    (from rezult in ClientMails
                    where rezult.ClientId == id
                    select rezult).ToList();
                client.Webs =
                        (from rezult in Webs
                        where rezult.ClientId == id
                        select rezult).ToList();
                client.ClientNotes =
                        (from rezult in ClientNotes
                         where rezult.ClientId == id
                         select rezult).ToList();
                client.ClientPhones =
                    (from rezult in ClientPhones
                     where rezult.ClientId == id
                     select rezult).ToList();
                

                return client;
            }
            else
            {
                return null;
            }
        }

        public List<Client> GetClients()
        {
            return Clients.Include(c => c.Employee)
                .Include(c => c.EnumTypeClient)
                .Include(c => c.Statuse)
                .Include(c => c.TypeClient)
                .Include(c => c.ClientPhones)
                .ToList();
        }
    }
}