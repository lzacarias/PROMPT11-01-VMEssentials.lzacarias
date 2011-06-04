using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BrowserTipos
{
    
    
    [Url]
    public class BrowseAllAssemb
    {

        public static FileInfo[] files;
        //static TextWriter tw;

        [Url("/as")]

 
        public static void Browse(TextWriter tw)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\");
            files = di.GetFiles("*.dll");

            foreach (FileInfo f in files)
            {
             
                BrowseAssembly.Browse(f.Name, tw, "all");
            }

        }
        

    }
}
