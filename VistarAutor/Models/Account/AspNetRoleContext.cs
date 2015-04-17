using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Account
{
    public class AspNetRoleContext : DbContext
    {
        public AspNetRoleContext() : base("VistarDb")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        //Возвращает Employee по id либо null
        public Employee GetEmployee(int? id)
        {
            if (id != null || Employees.Find(id) != null)
            {
                Employee employee = new Employee();
                List<Employee> employees = Employees.Include(p => p.Department).Include(p => p.Position).Include(p=>p.AspNetUser).ToList();
                employee = employees.Find(a => a.Id == id);
                return employee;
            }
            else
            {
                return null;
            }
        }

            public List<Employee> GetListEmployees()
        {
            return Employees.Include(p => p.AspNetUser).ToList();
        } 
    }
}