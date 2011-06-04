using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{

    //public class FiltraNome : IFilterPerson
    //{
    //    private string w;
    //    public FiltraNome(string word)
    //    { w = word; }

    //    public bool filter(Person p)
    //    {
    //        return p.Name.Contains("w");
    //    }



    //}

    public delegate bool FilterPerson(Person p);



    class Program
    {
        static void Main(string[] args)
        {

            //FilterPerson fp;

            School s1 = new School("isel");
            Teacher t1 = new Teacher("Carlos", 677871);
            s1.AddPerson(t1);
            School s2 = new School("iseg");
            Teacher t2 = new Teacher("Rui", 8451215);
            Student st1 = new Student("Rui", 1, 54);
            Student st2 = new Student("chico", 2, 55);
            Student st4 = new Student("chico", 4, 55);
            Student st9 = new Student("chico", 9, 55);
            s2.AddPerson(t2);
            t2.AddStudent(st1);
            t2.AddStudent(st2);
            t2.AddStudent(st9);
            s1.AddPerson(st1);
            s1.AddPerson(st2);
            Student st3 = new Student("2chico3", 3, 56);

            t1.Show();

            t2.Show();

            foreach (Student p in t2.Alunos)
            {
                p.Show();
            }

            bool st2_pertence;
            st2_pertence= t2.HasStudents(st2);
            Console.WriteLine("st2-pertence: " + st2_pertence);
           
            
            Console.WriteLine("st3-naopertence: " +t2.HasStudents(st3)) ;

            Console.WriteLine("st4-??naopertence: " + t2.HasStudents(st4));

            foreach (Person p in s1.Bonecos)
            {
                p.Show();
            }

            //Console.WriteLine(t1);
            //Console.WriteLine(t2);

            Console.WriteLine("separa");

            //s1.Show();
            //Console.WriteLine();
            //Console.WriteLine(t1);
            Console.WriteLine("separa1");
            //Ishowable [] tot = new Ishowable[5];
            
            //tot[0] = t1;
            //tot[1] = t2;
            //tot[2] = st1;
            //tot[3] = s1;
            //tot[4] = s2;

            //foreach (Ishowable i in tot)
            //{
            //    i.Show();
            //}


            Console.WriteLine("separa2");

            Student[] alunos_sort = new Student[4];
            alunos_sort[0] = st1;
            alunos_sort[1] = st2;
            alunos_sort[2] = st3;
            alunos_sort[3] = st4;

            Array.Sort(alunos_sort,new CompareStudentByNum());

            foreach (Student est in alunos_sort)
            {
                Console.WriteLine(est);
            }


            Array.Sort(alunos_sort, new CompareStudentByName());

            foreach (Student est in alunos_sort)
            {
                Console.WriteLine(est);
            }

            //FilterPerson fp1 = new FilterPerson(f);

            Console.WriteLine("bonecos chamados Rui");
            //Console.WriteLine(t2.getFilteredStudent(f));

            foreach ( Student st in t2.getFilteredStudent(f))
            {
                Console.WriteLine(st);
            }

            Console.WriteLine("bonecos chamados chico");
            //Console.WriteLine(t2.getFilteredStudent(f));

            print_stud(t2.getFilteredStudent(z));
    
            //lambda
            
            Console.WriteLine("lambda");
            Console.WriteLine("diga o nome:");
            
            //while  (nome == null)
            //{ Console.WriteLine("diga o nome:"); } 

            string nome = Console.ReadLine();
            print_stud(t2.getFilteredStudent(p => p.Name.Contains(nome)));

            Console.WriteLine("evento:");

            t1.Msg += st1.ReceiveMsg;
            t1.Msg += st2.ReceiveMsg;

            t1.SendMsg("publiquei notas");

            t1.Msg -= st2.ReceiveMsg;
            t1.SendMsg("já foste");
        }
        static bool f(Person p)
        {
            return p.Name.Contains("Rui");
        }

        static bool z(Person p)
        {
            return p.Name.Contains("chico");
        }

        static public void print_stud (Student[] s)
        {

            foreach (Student st in s )
            {
                st.Show();
            }
    
        }
    }
}
