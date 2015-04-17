using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Client
{
    public class Web
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public bool Main { get; set; }
    }
}