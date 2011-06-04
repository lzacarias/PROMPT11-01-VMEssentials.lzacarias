using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Teacher : Person
    {

        Student[] _alunos;
        //Dictionary<int, Person > _alunos;

        public Student[] Alunos
        {
            get { return _alunos; }
        }

        //public Dictionary<int,Person>.ValueCollection Alunos
        //{
        //    get { return _alunos.Values; }
        //}


        public Teacher(string name, int bi)
            : base(name, bi)
        {
            _alunos = new Student[0];
        }

        //public Teacher(string name, int bi)
        //    : base(name, bi)
        //{            
        //    _alunos = new Dictionary<int,Person>();
        //}
 
        public void AddStudent (Student st)
        {

            Student[] alunos1 = new Student[_alunos.Length + 1];

            int cont;
            for (cont = 0; cont < _alunos.Length; cont++)
            {

                alunos1[cont] = _alunos[cont];
            }

            alunos1[cont] = st;

            _alunos = alunos1; 

            //_alunos.Add(st.Bi, st);
        }

        public bool HasStudents(Student st)
        {

            foreach (Student p in _alunos)
            {
                //if (p.Bi == st.Bi)

                if (p.Equals(st))

                    return true;
            }

            return false;

            //return _alunos.ContainsKey(st.Bi);


        }

        public Student[] getFilteredStudent(FilterPerson fp)
        {
            int i = 0;
            Student[] StudFiltered = new Student[_alunos.Length]; 
            foreach (Student s in _alunos)
            {
                if (fp(s))      // equivale a  (fp(s) == true)  
                {
                    StudFiltered[i] = s;
                    i++;
                }

                
            }

            Student[] StudFilterFim = new Student[i];

            Array.Copy(StudFiltered, StudFilterFim, i);
            return StudFilterFim;

        }

        public event EventHandler<MsgArgs> Msg; // eventhandler é um delegate que recebe sermpre o 1º parametro object sender

        public void SendMsg(string txt)
            {Msg(this, new MsgArgs(txt)); }
  
    }

        //nova classe; fica aqui para ser mais rápido
        public class MsgArgs : EventArgs 
        {
           
            public string Msg { get;
                                set; } // definindo a propriedade Msg automaticamente gera uma string e faz set ou get
          

            public  MsgArgs (string txt)
                {Msg = txt;}
        }

}
