using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication4
{
    class Teacher : Person
        
    {
        Student[] _alunos;

        const int STUDENTES_CAPACITY = 10;

        public enum Categoria { coordenador, adjunto, assistente };
        Categoria _categoria;

        public Teacher(string name, DateTime birthdate, Categoria categoria)
            : base(name, birthdate)
        {
            _categoria = categoria;
            _alunos = new Student[STUDENTES_CAPACITY];
        }

         private Teacher() { _alunos = new Student[STUDENTES_CAPACITY]; }


        protected override void Read(StreamReader s, Person [] p)
        {

            base.Read(s,p);
            string linha;
            linha = s.ReadLine(); //categoria
            _categoria = (Categoria)Enum.Parse(typeof(Categoria), linha);

        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {

            string resultado = "Alunos: \n";

            foreach (Student p in this._alunos)
            {
               
                if (p != null)
                {
                    resultado += p.ToString()+"\n";

                }
             
            }

            return base.ToString() + " categoria= " + _categoria + "\n" +resultado; // base.tostring referencia para o proprio objecto considerando a classe base

        }

        public Categoria categoria { get { return _categoria; } }

        public override void SaveFile(StreamWriter s)
        {
            base.SaveFile(s);
            s.WriteLine(this._categoria);

        }

        public bool AddStudent(Student st)
        {

            int contador = 0;
            foreach (Student p in this._alunos)
            {
                if (p != null)
                {
                    contador++;
                }
                else
                {
                    this._alunos[contador] =  st;
                    return true; 
                }

            }
            return false;   
        }

    }
}
