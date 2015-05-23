using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Person
{
    public class MyPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public int ClientId { get; set; }
        public Client.Client Client { get; set; }
        public string Note { get; set; }

        public ICollection<PersonMail> PersonMails { get; set; }
        public ICollection<PersonPhone> PersonPhones { get; set; }

        public MyPerson()
        {
            PersonMails = new List<PersonMail>();
            PersonPhones = new List<PersonPhone>();
        }
    }
}