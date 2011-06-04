using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{

    [Url]
    public class BrowseConstructores
    {
        static TextWriter tw;

        [Url("/ns/{namespace}/{tipo}/c")]
        static public void Browse(string ns, string nt, TextWriter tw1)
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




            WriteConstrutores(nt1,ht);

            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }


        public static void WriteConstrutores(Type nt1, html ht)
        {
            ConstructorInfo[] construtores = nt1.GetConstructors();

            if (construtores.Length > 0)
            {
                ht.Heading2("Construtores:");
                ht.BeginList();
                foreach (ConstructorInfo p in construtores)
                {

                    tw.Write("<li> {0}", p.Name);
                    WriteParametros(p.GetParameters());
                    tw.WriteLine("</li>");
                }

                ht.EndList();
            }
        }

        public static void WriteParametros(ParameterInfo[] p)
        {

            if (p.Length > 0)
            {
                tw.Write(" (");

                bool first = true;
                foreach (ParameterInfo pm in p)
                {

                    if (first) first = false;
                    else
                        tw.Write(", ");
                    tw.Write("{0}", pm.Name + ":" + pm.ParameterType.Name);

                }
                tw.Write(")");
            }
        }



    }
}
