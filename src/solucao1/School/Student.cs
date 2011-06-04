using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Student : Person, IComparable <Student>
    {
        int _nr_aluno;

        public Student(string name, int  bi, int nr_aluno)
            : base(name, bi)
        {
            _nr_aluno = nr_aluno;
        }


        public int nr_aluno { get { return _nr_aluno; } }

        public int CompareTo(Student other)
        { 
            
            return (this._bi - other._bi); // faz a operação e devolve o valor

        }

        public void ReceiveMsg(object t, MsgArgs msg)
        {

            Console.WriteLine("aluno {0} recebeu {1} do professor {2}", this.Name, msg.Msg, ((Teacher)t).Name);
        }


    }

}
