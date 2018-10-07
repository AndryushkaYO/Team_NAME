namespace PersonStudentTeacher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Student's class
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="name">String student name</param>
        /// <param name="group">String group id</param>
        /// <param name="teacher">String teacher name</param>
        public Student(string name, string group, string teacher) : base(name)
        {
            Teacher = teacher;
            Group = group;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Student() : base()
        {
        }
        /// <summary>
        /// Property teacher
        /// </summary>
        public string Teacher { get; set; }
        /// <summary>
        /// Property group
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Overriden ToString func
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"{base.ToString()} {Group} Teacher:  {Teacher}";
        }
        /// <summary>
        /// Compares two students
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   base.Equals(obj) &&
                   EqualityComparer<string>.Default.Equals(Teacher, student.Teacher) &&
                   Group == student.Group;
        }
        /// <summary>
        /// Hash coding
        /// </summary>
        /// <returns>Int hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = 398198191;
            hashCode = (hashCode * -1521134295) + base.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Teacher);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Group);
            return hashCode;
        }
        /// <summary>
        /// Clones students
        /// </summary>
        /// <returns>Object</returns>
        public override object Clone()
        {
            return new Student(Name, Group, Teacher);
        }
        /// <summary>
        /// Input function
        /// </summary>
        /// <param name="args">Array of strings</param>
        public override void Input(string[] args)
        {
            Name = args[0];
            Group = args[1];
            Teacher = args[2];
        }
        /// <summary>
        /// Print function
        /// </summary>
        /// <param name="sw">StreamWriter</param>
        public override void Print(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
    }
}
