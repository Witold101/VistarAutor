using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistarAutor.Models.Account;

namespace VistarAutor.Models.Main
{
    public class AspNetUser
    {
        private string _id;

        public string Id {get { return _id; }
            set { _id = value.Length <= 128 ? value : value.Remove(127); }}
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string UserName { get; set; }

        public ICollection<AspNetRole> AspNetRoles { get; set; }
        public ICollection<Employee> Employees { get; set; } 

        public AspNetUser()
        {
            Employees=new List<Employee>();
            AspNetRoles=new List<AspNetRole>();
        }
    }
}