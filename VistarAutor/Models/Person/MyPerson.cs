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
        public string LastName { get; set; }
        public string PersonNamber { get; set; }
        public DateTime Birthday { get; set; }
        public int Photo { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int PersonTypeId { get; set; }
        public PersonType PersonType { get; set; }
        public int PersonStatuseId { get; set; }
        public PersonStatuse PersonStatuse { get; set; }
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