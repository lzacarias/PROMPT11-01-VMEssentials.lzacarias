using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class CompareStudentByNum : IComparer <Student>
    {

        public int Compare(Student s1, Student s2)

        {

            return (s1.Bi - s2.Bi);
        }
    }
}
