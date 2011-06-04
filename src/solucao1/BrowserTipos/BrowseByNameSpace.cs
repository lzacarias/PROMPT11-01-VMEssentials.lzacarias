using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace BrowserTipos
{
    [Url]
    public class BrowseByNameSpace
    {

 
            static TextWriter tw;

            [Url("/{Assembly.dll}/ns/{namespace}")]

            static public void Browse(string assemb, string nspace, TextWriter tw1)
            {
                tw = tw1;

                html ht = new html(tw, assemb);

                foreach (var ns in BrowseAssembly.dic.Keys)
                {
                    if (ns == nspace)
                    {

                        ht.Heading1("Informacao para o seguinte namespace:");

                        ht.BeginElementList();
                        ht.Paragraph(ns);
                        ht.EndElementList();
                        ht.BeginList();
                        BrowseAssembly.dic1 = BrowseAssembly.dic[ns]; // obter do dic1 o que estiver para a respectiva chave do dic
                        foreach (var nt in BrowseAssembly.dic1.Keys) // obtem as chaves de dic1
                        {

                            ht.BeginElementList();
                            
                            ht.LinkTipo(nt);
                            ht.EndElementList();
                        }
                        ht.EndList();
                    }
                }

                ht.EndList();
                ht.Close();

               
            }        
              
  }

}
