using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BrowserTipos
{
    public class html
    {
        TextWriter tw;


        public html(TextWriter tw1, string titulo1, string erro)
            : this(tw1, titulo1)
        {
            Heading2(erro);
            Close();
        }
 

        public html(TextWriter tw1, string titulo1)
        {
            tw = tw1;
            tw.WriteLine("<html><head><title>{0}</title></head>", titulo1);
            tw.WriteLine("<body>");
        }
        public  void Heading1(string s)
        {
            tw.WriteLine("<h1> {0} </h1>", s);
        }

        public  void Heading2(string s)
        {
            tw.WriteLine("<h2> {0} </h2>", s);
        }

        public void Close()
        {
            tw.WriteLine("</body>");
            tw.WriteLine("</html>");
        }


        public void BeginList()
        {tw.WriteLine("<ul>");
        }

        public void EndList()
        {tw.WriteLine("</ul>");
        }
        
        public void ElementList(string st)
        {tw.WriteLine("<li>{0}</li>", st);
        }

        public void BeginElementList()
        {tw.Write("<li>");}
        

        public void EndElementList()
        {tw.Write("</li>");}
        
        
        
        public void Paragraph(string st)
        {
            tw.WriteLine("<p>{0}</p>", st);
        }

        public void LinkTipo(string st)
        {

            string ns;
            string tipo;
            int i = st.LastIndexOf('.');
            if (i > 0)
            {
                ns = st.Substring(0, i);
                tipo = st.Substring(i + 1);
                tw.WriteLine("<a href = {0}/{1}>{2}</a>", Program.PREFIXO+"ns/" + ns,tipo,st);
            }else
            {
                tw.WriteLine("<a href = {0}/{1}>{1}</a>",Program.PREFIXO+"ns/",st);
            } 
        }


        public void LinkNs( string assemb, string ns)
        {

                tw.WriteLine("<a href = {0}/ns/{1}>{1}</a>", Program.PREFIXO + assemb, ns);
        }        


    }
}
