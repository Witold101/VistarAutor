using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Main
{
    public class CountryCodeContext:DbContext
    {
        public CountryCodeContext(): base("VistarDb")
        { }
        public DbSet<CountryCode> CountryCodes { get; set; }
    }
}