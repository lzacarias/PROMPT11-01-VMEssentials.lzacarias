using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
         
         bool found = false;   
         do {
            string fich;
            Console.Write("Indique ficheiro: ");

            fich = Console.ReadLine();

            try

            {
                var malta1 = Person.ReadFilePersons(fich);
                found = true;
                Console.WriteLine("Leu");
                foreach (Person elemento in malta1)
                {
                    Console.WriteLine(elemento);
                //    Console.WriteLine();
                }

            }
            catch (FileNotFoundException Erro)
            {
                found = false;
                Console.WriteLine("o ficheiro não existe");
                Console.Write("Indique ficheiro novamente: ");
                
            }

         } while (found == false);

        }
        
    }
}
