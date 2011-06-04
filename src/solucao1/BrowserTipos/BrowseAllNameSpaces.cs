using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{

    [Url]
    public class BrowseAllNameSpaces
 
    {
        static TextWriter tw;

        [Url("/ns")]

        static public void Browse(TextWriter tw1)
        {
            tw = tw1;

            //try
            //{
            //    foreach (FileInfo f in BrowseAllAssemb.files)
            //    {
            //        Assembly z = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\" + f.Name);
            //        Type[] x = z.GetExportedTypes();
            //        //falta foreach
            //        BrowseByNameSpace.Browse(f.Name, x.GetType().Namespace, tw);
            //    }
            //}
            //catch
            //{
                
            //}

            foreach (var b in BrowseAssembly.dic.Keys)
            {
                Type x = b.GetType();
                BrowseByNameSpace.Browse(x.Assembly.GetName().Name, b, tw);

            }

        }        

       

    }
}
