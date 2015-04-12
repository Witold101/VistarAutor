using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistarAutor.Models.Main;

namespace VistarAutor.Models.Client
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime DateTimeRegistration { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int EnumTypeClientId { get; set; }
        public EnumTypeClient EnumTypeClient { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TypeClientId { get; set; }
        public TypeClient TypeClient { get; set; }
        public int StatuseId { get; set; }
        public Statuse Statuse { get; set; }
    }
}