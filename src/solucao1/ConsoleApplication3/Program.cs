using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main1(string[] args)
        {
            var Empregado = new Empregado("Zaca", 15);
            Empregado.Mostra();

            var Empregado1 = new Empregado("Zaca1", 151);
            Empregado1.Mostra();

            var Patrao = new Patrao("Fachista", 50, 54512);
            Patrao.Mostra();
            Patrao.MostraAccoes();
        }

        static void Main(string[] args)
        {
            Empregado[] trabalhadores = new Empregado[]
            {
                new Empregado ("Zaca", 15),
                new Empregado ("Zaca1", 151),
                new Patrao ("facho", 100, 51215)
            };
        
        
            for (int i= 0; i< trabalhadores.Length;i ++) 
            {
                trabalhadores[i].Mostra();
                trabalhadores[i].MostraNome();
                trabalhadores[i].MostraFuncao();
                Console.WriteLine();
            }
        }
 


    }




    class Empregado
    {

        protected string nome;
        private int idade;

        public Empregado(string nomepessoa, int idadepessoa)
        {
            nome = nomepessoa;
            idade = idadepessoa;

        }

        public void Mostra()
        {
            Console.WriteLine ("{0} tem {1} anos", nome, idade);
           
        }

        public void MostraNome()
        {
            Console.WriteLine("{0}", nome);

        }

        public virtual void MostraFuncao()
        {
            Console.WriteLine("Empregado");

        }


    }

    class Patrao : Empregado
    {
        private int numaccoes;
        public Patrao(string nomepatrao, int idadepatrao, int nraccoes_patrao)
            : base(nomepatrao, idadepatrao)
        {
            numaccoes = nraccoes_patrao;
        }

        public void MostraAccoes()
        {
            Console.WriteLine("{0} tem {1} acções", nome, numaccoes);

        }

        public override void MostraFuncao()
        {
            Console.WriteLine("Patrao");

        }



    }


}
