namespace PersonStudentTeacher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Person's class.
    /// Contains IO Clone GetHashCode ToString methods 
    /// </summary>
    public class Person : ICloneable
    {
        /// <summary>
        /// Persons name.
        /// </summary>
        private string name;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Person()
        {
        }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="name">Person's string name</param>
        public Person(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// Name's property
        /// </summary>
        public string Name { get => this.name; set => this.name = value; }
        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   this.Name == person.Name;
        }
        /// <summary>
        /// Name hash coding 
        /// </summary>
        /// <returns>Int hash code</returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Cloned item as object</returns>
        public virtual object Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Overriden ToString function
        /// </summary>
        /// <returns>String name</returns>
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// Input function
        /// </summary>
        /// <param name="args">Array of strings</param>
        public virtual void Input(string[] args)
        {
            Name = args[0];
        }
        /// <summary>
        /// Print function
        /// </summary>
        /// <param name="sw">Streamwriter</param>
        public virtual void Print(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
    }
}
