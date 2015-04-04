using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistarAutor.Models.Account
{
    public class AspNetRole
    {
        private string _id;
        private string _name;

        public string Id
        {
            get { return _id; }
            set
            {
                if (value.Length <= 128)
                {
                    _id = value;
                }
                else
                {
                    _id = value.Remove(128);
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length <= 256)
                {
                    _name = value;
                }
                else
                {
                    _name = value.Remove(256);
                }
            }
        }
    }
}