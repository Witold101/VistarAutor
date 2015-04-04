using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class DepartmentContext:DbContext
    {
        public DepartmentContext(): base("VistarDb")
        { }
        public DbSet<Department> Departments { get; set; }
    }
}