using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class CompareStudentByName : IComparer<Student> 
    {

        public int Compare (Student s1, Student s2)
        {

            return s1.Name.CompareTo(s2.Name);
        }

    }
}
