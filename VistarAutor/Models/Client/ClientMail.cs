using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace VistarAutor.Models.Client
{
    public class ClientMail
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public bool Main { get; set; }
    }
}