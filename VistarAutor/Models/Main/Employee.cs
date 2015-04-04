using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VistarAutor.Models.Account;

namespace VistarAutor.Models.Main
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonNamber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DayOfEmployment { get; set; }
        public DateTime DayOfDismissal { get; set; }
        public int Photo { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }
        
        public ICollection<EmployeeMail> EmployeeMails { get; set; }
        public ICollection<string> Roles { get; set; }

        public Employee()
        {
            EmployeeMails = new List<EmployeeMail>();
            Roles=new List<string>();
        }
    }
}