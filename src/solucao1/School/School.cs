using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class School  : Ishowable
    {
      string  _name;

      LinkedList<Person> _bonecos;

      public LinkedList<Person> Bonecos
      {
          get { return _bonecos; }
      }

     
      public School(string name)
      {
          _name = name; 
          _bonecos = new LinkedList<Person>();
      }

      public void AddPerson(Person p)
      {
          p.Institution = this;
          _bonecos.AddLast(p); 
      }

      public string Name
      {
          get { return _name; }
      }

      public void Show()
      {
          Console.WriteLine("Nome: {0}",_name);
          
          foreach (Person p in _bonecos)
             { Console.WriteLine("boneco: {0}", p);}
      
          
      }
  
      

    }
}
