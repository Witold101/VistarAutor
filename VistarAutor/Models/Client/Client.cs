using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Client
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime DateTimeRegistration { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int EnumTypeClientId { get; set; }
        public EnumTypeClient EnumTypeClient { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TypeClientId { get; set; }
        public TypeClient TypeClient { get; set; }
        public int StatuseId { get; set; }
        public Statuse Statuse { get; set; }

        public ICollection<ClientMail> ClientMails { get; set; }
        public ICollection<Web> Webs { get; set; }
        public ICollection<ClientNote> ClientNotes { get; set; }
        public ICollection<ClientPhone> ClientPhones { get; set; }
        public ICollection<ClientAddresse> ClientAddresses { get; set; } 

        public Client()
        {
            ClientMails=new List<ClientMail>();
            Webs=new List<Web>();
            ClientNotes=new List<ClientNote>();
            ClientPhones = new List<ClientPhone>();
            ClientAddresses=new List<ClientAddresse>();  
        }
    }
}