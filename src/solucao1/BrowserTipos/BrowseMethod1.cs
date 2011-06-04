using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{
    [Url]
    public class BrowseMethod
    {
        static TextWriter tw;

        [Url("/ns/{namespace}/{tipo}/m/{methodname}")]
        static public void Browse(string ns, string nt, string mt, TextWriter tw1)
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


            ht.Heading1("Tipo: " + nt1.FullName);



            WriteMethods(nt1, ht, mt);



            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }


        private static void WriteMethods(Type nt1, html ht, string mt)
        {
            MethodInfo[] metodos = nt1.GetMethods();
            //if (metodos.Length > 0) Heading2("Methods:");
            {
                ht.BeginList();
                foreach (MethodInfo p in metodos)
                {
                    if (p.Name != mt)
                        continue;
                    tw.Write("<li> {0}", p.Name);
                    if (p.IsStatic) tw.Write(" S");


                    WriteParametros(p.GetParameters());

                    tw.WriteLine("</li>");

                }

                ht.EndList();
            }
        }

        private static void WriteParametros(ParameterInfo[] p)
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
