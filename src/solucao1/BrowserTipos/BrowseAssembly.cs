using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BrowserTipos
{
    [Url ]
    public class BrowseAssembly
    {

        static TextWriter tw;

        public static SortedDictionary<string, SortedDictionary<string, Type>> dic;
        public static SortedDictionary<string, Type> dic1;
        

        [Url ("/as/{Assembly.dll}" ) ]
          
        static public void Browse(string assemb, TextWriter tw1)
        {

            tw = tw1;
            //tw.WriteLine("<html><head><title>Erro</title></head>");
            //tw.WriteLine("<body>");
            //tw.WriteLine("Tipo de nome nao encontrado");
            //tw.WriteLine("</body>");
            //tw.WriteLine("</html>");


            try
            {
                Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\" + assemb);

                html ht = new html(tw, assemb);

                Type[] ass_types = ass.GetExportedTypes();

                ht.Heading1(assemb);
                //ht.Heading1("<a href = assemb >assemb</a>" );

                string local = ass.Location;
                ht.Paragraph(local);

                ht.Heading2("Tipos:");

                ht.BeginList();
                //SortedDictionary<string, SortedDictionary<string, Type>> dic;
                dic = new SortedDictionary<string, SortedDictionary<string, Type>>();
                //SortedDictionary<string, Type> dic1;
                foreach (Type tp in ass_types)
                {
                 
                    string s = tp.Namespace;
                    if (s == null)
                        {
                            s = "";
                        }
                        
                    if (!dic.TryGetValue(s, out dic1))
                    {
                        dic.Add(s, dic1=new SortedDictionary<string, Type>());
                    }
                    
                    dic1.Add(tp.FullName, tp);
                    //ht.BeginElementList();
                    //ht.link(tp.FullName);
                    //ht.EndElementList();

                }

                foreach (var ns in dic.Keys)
                {
                    if (ns != "")
                    {
                        ht.BeginElementList();
                        //ht.Paragraph(ns);
                        ht.LinkNs(assemb, ns);
                        ht.EndElementList();
                        ht.BeginList();
                        dic1 = dic[ns]; // obter do dic1 o que estiver para a respectiva chave do dic
                        foreach (var nt in dic1.Keys) // obtem as chaves de dic1
                        {

                            ht.BeginElementList();
                            //ht.link(dic1[nt].FullName);
                            ht.LinkTipo(nt);
                            ht.EndElementList();
                        }
                        ht.EndList();
                    }
                }


                ht.EndList();
                ht.Close();

                

            }
            catch (Exception e)
            {
                   html ht = new html(tw, "Erro", e.Message);
                    
            }

        }


        static public void Browse(string assemb, TextWriter tw1, string fun)
        {

            tw = tw1;

            try
            {

                
                Assembly ass = Assembly.LoadFrom(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\" + assemb);
                html ht = new html(tw, assemb);

                
                Type[] ass_types = ass.GetExportedTypes();

                //ht.Heading1(assemb);
                ht.Heading1("<a href = /as/"+ assemb+">"+assemb+"</a>" );

                string local = ass.Location;
                ht.Paragraph(local);

                ht.Heading2("Tipos:");

                ht.BeginList();
                //SortedDictionary<string, SortedDictionary<string, Type>> dic;
                dic = new SortedDictionary<string, SortedDictionary<string, Type>>();
                //SortedDictionary<string, Type> dic1;
                foreach (Type tp in ass_types)
                {

                    string s = tp.Namespace;
                    if (s == null)
                    {
                        s = "";
                    }

                    if (!dic.TryGetValue(s, out dic1))
                    {
                        dic.Add(s, dic1 = new SortedDictionary<string, Type>());
                    }

                    dic1.Add(tp.FullName, tp);
                    //ht.BeginElementList();
                    //ht.link(tp.FullName);
                    //ht.EndElementList();

                }

                foreach (var ns in dic.Keys)
                {
                    if (ns != "")
                    {
                        ht.BeginElementList();
                        //ht.Paragraph(ns);
                        ht.LinkNs(assemb, ns);
                        ht.EndElementList();
                        ht.BeginList();
                        dic1 = dic[ns]; // obter do dic1 o que estiver para a respectiva chave do dic
                        foreach (var nt in dic1.Keys) // obtem as chaves de dic1
                        {

                            ht.BeginElementList();
                            //ht.link(dic1[nt].FullName);
                            ht.LinkTipo(nt);
                            ht.EndElementList();
                        }
                        ht.EndList();
                    }
                }


                ht.EndList();
                ht.Close();



            }
            catch (Exception e)
            {



            }

        }





    }
}
