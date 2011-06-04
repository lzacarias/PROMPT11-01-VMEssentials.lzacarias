using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{

    [Url]
    public class BrowseType
    {
        static TextWriter tw;
 
        [Url ("/ns/{namespace}/{tipo}")  ]
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


            Heading1("Tipo: "+nt1.FullName);
            //tw.WriteLine("<h1> Tipo: {0}</h1>", nt1.FullName);



            WriteAssembly(nt1, ht);


            WriteCampos(nt1, ht);
            WriteMethods(nt1, ht);
            WriteConstrutores(nt1, ht);

            WritePropriedades(nt1, ht);
            WriteEventos(nt1);
                
            

            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }

        private static void WritePropriedades(Type nt1, html ht)
        {
            PropertyInfo[] prop = nt1.GetProperties();
            if (prop.Length == 0) return ;

            Heading2("Propriedades:");
            ht.BeginList();
            foreach (PropertyInfo pi in prop)
            { 
                ht.BeginElementList();
                tw.Write(" {0}, tipo: {1}, tem set: {2}, tem get: {03}", pi.Name, pi.PropertyType.Name, pi.CanWrite ? 'S': 'N', pi.CanRead ? 'S': 'N');
                ht.EndElementList();
                
            }
            ht.EndList();
        }

        private static void WriteAssembly(Type nt1, html ht)
        {

            string nome_completo_assembly = nt1.Assembly.FullName;
            string nome_assembly = nt1.Assembly.GetName().Name;
            string local_assembly = nt1.Assembly.Location;

    
                 

            Heading2("Informacao Assembly:");
            ht.BeginList();

            ht.BeginElementList();
            tw.Write("<a href ={0}as/{1}.dll> {2} </a>,", Program.PREFIXO,nome_assembly, nome_assembly);
            tw.Write("nome_completo: {0}, localizacao: {1}",nome_completo_assembly, local_assembly);
            ht.EndElementList();

            ht.EndList();
        }



        private static void WriteCampos(Type nt1, html ht)
        {
            FieldInfo[] campos = nt1.GetFields();
            
            if (campos.Length == 0) return;

            Heading2("Campos:");
            ht.BeginList();
            foreach (FieldInfo fi in campos)
            {
                ht.BeginElementList();
                tw.Write(" {0}, tipo: {1}", fi.Name, fi.FieldType.Name); 
                ht.EndElementList();
                

            }
            ht.EndList();



        }

        public static void WriteEventos(Type nt1)
        {
            
            EventInfo[] eventos = nt1.GetEvents();

            if (eventos.Length == 0) return;

            Heading2("Eventos:");
            tw.WriteLine("<ul>");
            foreach (EventInfo ev in eventos)
            {
                tw.Write("<li>");
                tw.Write(" {0}, tipo: {1}", ev.Name, ev.EventHandlerType.Name); 
                tw.WriteLine("</li>");
                

            }
            tw.WriteLine("</ul>");



        }

       
        private static void WriteMethods(Type nt1, html ht)
        {
            MethodInfo[] metodos = nt1.GetMethods();
            if (metodos.Length > 0)  Heading2("Methods:");
            {
                ht.BeginList();
                foreach (MethodInfo p in metodos)
                {
                    tw.Write("<li> {0}", p.Name);
                    if (p.IsStatic) tw.Write(" S");


                    WriteParametros(p.GetParameters());
                   
                    tw.WriteLine("</li>");

                }

                ht.EndList();
            }
        }

        public static void WriteConstrutores(Type nt1, html ht)
        {
            ConstructorInfo[] construtores = nt1.GetConstructors();

            if (construtores.Length > 0)
            {
                Heading2("Construtores:");
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

        public  static void WriteParametros(ParameterInfo[] p)
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

        public static void Heading1(string s)
        {
            tw.WriteLine("<h1> {0} </h1>", s);
        }

        public static void Heading2(string s)
        {
            tw.WriteLine("<h2> {0} </h2>", s);
        }


    }
}
