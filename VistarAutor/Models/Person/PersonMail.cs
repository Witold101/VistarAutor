using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Person
{
    public class PersonMail
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public bool Main { get; set; }
        public int MyPersonId { get; set; }
        public MyPerson MyPerson { get; set; }
    }
}