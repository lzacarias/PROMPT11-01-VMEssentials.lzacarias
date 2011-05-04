

namespace Sessao1
{
    class Program
    {
        static void Main(string[] args)
        {
          Ponto p1;
		  Ponto p2;
		  p1=new Ponto(3,9);
		  p2=new Ponto(3,4);
		  
		  int Res;
		  Res = p1.Distance(p2);
		  System.Console.WriteLine("Res= {0} ",Res);
		  
		  string Res1 = p2.ToString();
		  System.Console.WriteLine("Res1= {0} ",Res1);
		  
        }
    }
}
