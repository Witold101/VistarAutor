using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class PositionContext:DbContext
    {
        public PositionContext(): base("VistarDb")
        {}
        public DbSet<Position> Positions { get; set; }
    }
}