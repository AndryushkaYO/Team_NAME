using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentTeacher
{
    public  class Person : ICloneable 
    {
        private string _name;

        protected Person(string name)
        {
            Name = name;
        }

        public Person()
        {
        }

        public string Name { get => _name; set => _name = value; }

        public override bool Equals(object obj)
        { 
            var person = obj as Person;
            return person != null &&
                   Name == person.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            return Name;
        }

        public virtual void Input(string[] args)
        {
            Name = args[0];
        }

        public virtual void OutPut(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
    }
}
