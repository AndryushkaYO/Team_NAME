namespace PersonStudentTeacher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Person : ICloneable
    {
        private string name;
        public Person()
        {
        }
        public Person(string name)
        {
            this.Name = name;
        }
        public string Name { get => this.name; set => this.name = value; }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   this.Name == person.Name;
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
