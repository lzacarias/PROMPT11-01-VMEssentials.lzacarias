using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrowserTipos
{
    public class UrlAttribute : Attribute
    {

        public string _st;
        public UrlAttribute(string st)
        { 
            _st = st;
        }

        public UrlAttribute()
        { }

    }
}
