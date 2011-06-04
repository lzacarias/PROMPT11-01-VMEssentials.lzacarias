using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BrowserTipos
{
    [Url]
    public class Root
    {
        static TextWriter tw;

        [Url("/")]

        public static void Browse(TextWriter tw)

        { 
     
            //tw.WriteLine("<html><head><title>{0}</title></head>", nome);
            //tw.WriteLine("<body>");

            html ht = new html(tw, "Início");


            ht.Heading1("<a href = as>Assemblies</a>");;
         


            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }



    }
}
