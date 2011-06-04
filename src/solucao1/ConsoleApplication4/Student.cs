using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication4
{
    class Student : Person
    {
        int _nr_aluno;

        public Student(string name, DateTime birthdate, int nr_aluno)
            : base(name, birthdate)
        {
            _nr_aluno = nr_aluno;
        }

        private Student() { }


        protected override void Read(StreamReader s, Person [] p)
        {

            base.Read(s, p);
            string linha;
            linha = s.ReadLine(); //nr aluno
            _nr_aluno = int.Parse(linha);
            linha = s.ReadLine(); //id professor
            int id_professor;
            id_professor = int.Parse(linha);

            foreach (Person t in p)
            {
                
                
                if ((t != null) && (t.Id == id_professor))
                { Teacher x = t as Teacher;
                x.AddStudent(this);   
                }
                        

            }


        }

        public override string ToString() // com override passa por cima do to string que existe em object
        {
            return base.ToString() + " nr_aluno= " + _nr_aluno; // base.tostring referencia para o proprio objecto considerando a classe base

        }

        public int nr_aluno { get { return _nr_aluno; } }

        public override void SaveFile(StreamWriter s)
        {
            base.SaveFile(s);
            s.WriteLine(this._nr_aluno);

        }


    }

}
