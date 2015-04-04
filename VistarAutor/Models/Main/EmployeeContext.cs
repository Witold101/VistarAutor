using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext()
            : base("VistarDb")
        {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }

        public List<Employee> GetListEmployees()
        {
            return Employees.ToList();
        }
    }
}