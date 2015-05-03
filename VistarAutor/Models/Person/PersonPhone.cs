using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Person
{
    public class PersonPhone
    {
        public int Id { get; set; }
        public int CityCod { get; set; }
        public string NamberPhone { get; set; }
        public bool Main { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public int PersonId { get; set; }
        public MyPerson Person { get; set; }
        public int CountryCodeId { get; set; }
        public CountryCode CountryCode { get; set; }
    }
}