using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{
    [Url]
    public class BrowseFields
    {

        static TextWriter tw;

        [Url("/ns/{namespace}/{tipo}/f/{fieldname}")]
        static public void Browse(string ns, string nt, string fi, TextWriter tw1)
        {
    
            tw = tw1;
            string nome_completo = ns + "." + nt;
            Type nt1 = Type.GetType(nome_completo);
            
            
            

            if (nt1 == null)
            {
                tw.WriteLine("<html><head><title>Erro</title></head>");
                tw.WriteLine("<body>");
                tw.WriteLine("Tipo de nome nao encontrado");
                tw.WriteLine("</body>");
                tw.WriteLine("</html>");
                return;
            }
            
            string nome = nt1.FullName;

            //tw.WriteLine("<html><head><title>{0}</title></head>", nome);
            //tw.WriteLine("<body>");

            html ht = new html(tw, nome);


            ht.Heading1("Tipo: "+nt1.FullName);
            //tw.WriteLine("<h1> Tipo: {0}</h1>", nt1.FullName);




            WriteCampos(nt1, fi, ht);

            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }



        private static void WriteCampos(Type nt1, string campo, html ht)
        {
            FieldInfo[] campos = nt1.GetFields();
            
            if (campos.Length == 0) return;

            
            ht.BeginList();
            foreach (FieldInfo fi in campos)
            {
                if (fi.Name != campo)
                    continue;
                ht.Heading2("Informacao sobre o campo: " + fi.Name);
                ht.BeginElementList();
        
                tw.Write(" tipo: {0}", fi.FieldType.Name); 
                ht.EndElementList();
                

            }
            ht.EndList();



        }

        private static void WriteParametros(ParameterInfo[] p)
        {
            
            if (p.Length > 0)
            {
                tw.Write(" ("); 

                bool first = true;
                foreach (ParameterInfo pm in p)
                {

                    if (first)  first = false;  
                    else
                        tw.Write(", ");
                    tw.Write("{0}", pm.Name + ":" + pm.ParameterType.Name);
                    
                }
                tw.Write(")");
            }
        }



            
    
    }
}
