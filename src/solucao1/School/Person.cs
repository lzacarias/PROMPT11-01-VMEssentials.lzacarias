using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public abstract class Person : Ishowable
    {

        protected string _name;
        protected int _bi;
        protected School _school;

        public string Name // criar uma propriedade chamada Nome
        {

            get { return _name; } // código a ser efectuado no momento da leitura

            set { _name = value; } // código a ser efectuado no momento da escrita

        }

        public int Bi
        {
            get { return _bi; }

        }


        public School Institution
        {

            get { return _school; }

            set { _school = value; }
        }


        //construtores - quando o objecto é criado fica logo num estado integro, iniciado

        public Person(string name, int bi)
        {

            _name = name; // chama a propriedade Name usando o set
            _bi = bi;

        }

        // métodos - acções, procedimentos

        public virtual void Show()
        {
            //Console.Write("Nome: {0}, bi: {1}",
            //_name,
            //_bi);

            //if (_school != null)
            //    { Console.WriteLine(", escola: {0}", _school.Name); }
            //else
            //     { Console.WriteLine(); }

            Console.WriteLine(this.ToString());
        }

      
        public override bool Equals(Object p) // a classe tem de ser object pois essa é que tem a classe Equals de onde se está a fazer overrride
        {
            Person t; // definir uma variável do tipo Person
            t = p as Person; // tenta atribuir a t a referência de p; se consegue ok, caso não consiga t fica a null

  
            return (t!=null) && (_bi == t._bi );// avalia a expressão e retorna true or false
              
        }

        public override int GetHashCode()
        {
            return Bi;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            sb.AppendFormat("Nome: {0}, bi: {1}", _name, _bi);
           
            sb.AppendLine();

            if (_school != null)
            { sb.AppendFormat(", escola: {0}", _school.Name); }

            return sb.ToString();
            //return string.Format ("Nome: {0}, bi: {1}", _name,_bi);
        
            
        }

        

    }
}

