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
        
        public Employee GetEmployee(int? id)
        {
            if (id != null||Employees.Find(id)!=null)
            {
                Employee employee = new Employee();
                employee = Employees.Find(id);
                
                if (employee.DepartmentId != null)
                {
                    employee.Department = (from rezult in Departments
                        where rezult.Id == employee.DepartmentId
                        select rezult).First();
                }
                if (employee.PositionId != null)
                {
                    employee.Position = (from rezult in Positions
                        where rezult.Id == employee.PositionId
                        select rezult).First();
                }
                if (employee.AspNetUserId != null)
                {
                    employee.AspNetUser = (from rezult in AspNetUsers
                        where rezult.Id == employee.AspNetUserId
                        select rezult).First();

                    //******************************************
                    //ApplicationDbContext db = new ApplicationDbContext();
                    //employee.AspNetUser.AspNetRoles =
                    //    (ICollection<AspNetRole>) (from r in db.Roles
                    //    where r.Id == employee.AspNetUserId
                    //    select r).ToList();
                   
          
                    //*********************************************
                }
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