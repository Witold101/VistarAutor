using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Client
{
    public class ClientAddresse
    {
        public int Id { get; set; }
        public int CountryCodeId { get; set; }
        public CountryCode CountryCode { get; set; }
        public string City { get; set; }
        public string Addresse { get; set; }
        public string PostCode { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public bool Main { get; set; }
    }
}