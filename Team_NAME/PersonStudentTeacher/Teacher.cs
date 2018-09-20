namespace PersonStudentTeacher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Teacher's class
    /// </summary>
    public class Teacher : Person
    {
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="name">String name</param>
        /// <param name="degree">String degree</param>
        /// <param name="students">List of members of class Student</Student></param>
        public Teacher(string name, string degree, List<Student> students) : base(name)
        {
            Students = students;
            Degree = degree;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Teacher()
        {
        }
        /// <summary>
        /// List of students
        /// </summary>
        public List<Student> Students { get; set; } = new List<Student>();
        /// <summary>
        /// Teacher's degree
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            string res = $"{Name} {Degree} Students:";
            foreach (var student in Students)
            {
                res += "\r\n" + student.ToString();
            }
            return res;
        }
        /// <summary>
        /// Clone function
        /// </summary>
        /// <returns>Cloned object</returns>
        public override object Clone()
        {
            return new Teacher(Name, Degree, new List<Student>(Students));
        }
        /// <summary>
        /// Input function
        /// </summary>
        /// <param name="args">Array of strings</param>
        public override void Input(string[] args)
        {
            Name = args[0];
            Degree = args[1];
        }
        /// <summary>
        /// Print function
        /// </summary>
        /// <param name="sw">StreamWriter</param>
        public override void Print(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
        /// <summary>
        /// Compares two
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            var teacher = obj as Teacher;
            return teacher != null &&
                   base.Equals(obj) &&
                   EqualityComparer<string>.Default.Equals(Degree, teacher.Degree);
        }
        /// <summary>
        /// Hash code function 
        /// </summary>
        /// <returns>Int hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = 466891968;
            hashCode = (hashCode * -1521134295) + base.GetHashCode();           
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Degree);
            return hashCode;
        }
    }
}
