using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;
using VistarAutor.Models.Person;

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
        public DbSet<ClientAddresse> ClientAddresses { get; set; }
        public DbSet<MyPerson> MyPersons { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }

        public Client GetClient(int? id)
        {
            if (id != null && Clients.Find(id) != null)
            {
                Client client = GetClients().Find(c => c.Id == id);
                client.ClientPhones =
                    ClientPhones.Include(c => c.CountryCode)
                        .Include(c => c.PhoneType)
                        .Include(c => c.Client)
                        .ToList().
                        FindAll(c => c.ClientId == id);
                client.ClientAddresses =
                    ClientAddresses.Include(c => c.CountryCode)
                        .ToList()
                        .FindAll(c => c.ClientId == id);
                client.MyPersons =
                    MyPersons.Include(c => c.Client)
                        .Include(c => c.PersonMails)
                        .Include(c => c.PersonPhones)
                        .ToList()
                        .FindAll(c => c.ClientId == id);

                return client;
            }
            else
            {
                return null;
            }
        }

        public List<Client> GetClients()
        {

            List<Client> clients = Clients.Include(c => c.Employee)
                .Include(c => c.EnumTypeClient)
                .Include(c => c.Statuse)
                .Include(c => c.TypeClient)
                .Include(c => c.ClientAddresses)
                .Include(c => c.ClientMails)
                .Include(c => c.ClientNotes)
                .Include(c => c.ClientPhones)
                .Include(c => c.Webs)
                .Include(c => c.MyPersons)
                .ToList();
           
            return clients;
        }
    }
}