using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class EmployeeMail
    {
        public int Id { get; set; }
        public string Maill { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool Main { get; set; }
    }
}