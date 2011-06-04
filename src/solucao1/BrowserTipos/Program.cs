using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Reflection;




namespace BrowserTipos
{
    class Program
    {

        public static string PREFIXO = "http://localhost:8080/"; 
        //public event EventHandler<EventArgs> Msg; 
        
        //public string system; 
        public static void Main(string[] args)
        {

            HttpListener hl = new HttpListener();
            hl.Prefixes.Add(PREFIXO);
            hl.Start();
            for (; ; )
            {

                var ctx = hl.GetContext();
                string url = ctx.Request.RawUrl;
                Console.WriteLine("Request: " + url);



                //using (var tw = new StreamWriter("res.html"))
                using ( var tw = new StreamWriter(ctx.Response.OutputStream))
                {

                    

                    //BrowseType.Browse("System.IO", "DirectoryInfo", tw);
                    //BrowseType.Browse("BrowserTipos", "Program", tw);
                    //BrowseType.Browse("System", "Object", tw);
                    


                    Assembly NossoAssembly = Assembly.GetExecutingAssembly();
                    Type [] n1= NossoAssembly.GetExportedTypes();

                    foreach (Type n in n1)
                    {
                        if (!n.IsDefined(typeof(UrlAttribute), false)) 
                            { continue; } 
                        MethodInfo[] met = n.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                        foreach (MethodInfo mt in met)
                        {
                            if (!mt.IsDefined(typeof(UrlAttribute), false)) continue;


                            var mt_atrib = (UrlAttribute)mt.GetCustomAttributes(typeof(UrlAttribute), false)[0];
                            string[] p;
                            if (Program.CompareUrl(mt_atrib._st, url, out p))
                            {
                                //ParameterInfo[] par = mt.GetParameters();
                               
                                object[] arg = new object[p.Length+1];
                                int i;
                                for (i = 0; i < p.Length; i++)
                                {
                                    arg[i] = p[i];
                                }

                                arg[p.Length] = tw;

                                mt.Invoke(null, arg);
                            }
                        }


                    }

                }

                    
            }
            //hl.Stop();
        }

        public static bool CompareUrl(string url, string url_site,  out string [] param)
            //url = url do atributo de cada método, 
            //url_site = url que é passada ao servidor 

        {

            string[] url1 = url.Split('/');
            string[] url2 = url_site.Split('/');

            string[] url_aux = url.Split('{');

            param = null;
            int v = 0;

            if (url1.Length != url2.Length)
                return false;

            param = new string[url_aux.Length-1];

            

            for (int i = 0; i < url1.Length; i++)
            {
                if ((url1[i].Length == 0) &&
                    (url2[i].Length != 0))
                    return false;

                if (url1[i].Length == 0)
                    continue;

                if (url1[i][0] != '{')
                {
                    if (!url1[i].Equals(url2[i]))
                        return false;
                    //else
                    //{
                    //    param[v] = url2[i];
                    //    v++;
                    // }
                }
                else
                {
                    param[v] = url2[i];
                    v++;
                }
            }



            return true;
        }
    }
}