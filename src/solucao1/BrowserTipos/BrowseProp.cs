using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{
    [Url]
    public class BrowseProp
    {

        static TextWriter tw;

        [Url("/ns/{namespace}/{tipo}/p/{propriedades}")]
        static public void Browse(string ns, string nt, string pr, TextWriter tw1)
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
            //tw.WriteLine("<h1> Tipo: {0}</h1>", nt1.FullName);




            WritePropriedades(nt1, pr, ht);

            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }


        private static void WritePropriedades(Type nt1, string propriedade, html ht)
        {
            PropertyInfo[] prop = nt1.GetProperties();
            if (prop.Length == 0) return;

            ht.Heading2("Propriedades:");
            ht.BeginList();
            foreach (PropertyInfo pi in prop)
            {

                if (pi.Name != propriedade)
                    continue;
                ht.BeginElementList();
                tw.Write(" {0}, tipo: {1}, tem set: {2}, tem get: {03}", pi.Name, pi.PropertyType.Name, pi.CanWrite ? 'S' : 'N', pi.CanRead ? 'S' : 'N');
                ht.EndElementList();

            }
            ht.EndList();
        }


    }



}
