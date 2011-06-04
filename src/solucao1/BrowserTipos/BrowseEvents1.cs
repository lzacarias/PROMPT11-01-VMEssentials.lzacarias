using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{
    [Url]   
    public class BrowseEvents
    {
        static TextWriter tw;

        [Url("/ns/{namespace}/{tipo}/e/{eventos}")]
        static public void Browse(string ns, string nt, string en, TextWriter tw1)
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



            
            WriteEventos(nt1, en, ht);

            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }

        public static void WriteEventos(Type nt1, string evento, html ht)
        {

            EventInfo[] eventos = nt1.GetEvents();

            if (eventos.Length == 0) return;

            ht.Heading2("Eventos:");
            tw.WriteLine("<ul>");
            foreach (EventInfo ev in eventos)
            {
                if (ev.Name != evento)
                    continue;
 
                tw.Write("<li>");
                tw.Write(" {0}, tipo: {1}", ev.Name, ev.EventHandlerType.Name);
                tw.WriteLine("</li>");


            }
            tw.WriteLine("</ul>");



        }



 

    }
}
