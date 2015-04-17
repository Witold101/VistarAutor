using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Client
{
    public class ClientNote
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}