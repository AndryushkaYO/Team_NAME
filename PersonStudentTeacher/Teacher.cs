namespace PersonStudentTeacher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Teacher : Person
    {
        public Teacher(string name, string degree, List<Student> students) : base(name)
        {
            Students = students;
            Degree = degree;
        }

        public Teacher()
        {
        }
        public List<Student> Students { get; set; } = new List<Student>();
        public string Degree { get; set; }

        public override string ToString()
        {
            string res = $"{Name} {Degree} Students:";
            foreach (var student in Students)
            {
                res += "\r\n" + student.ToString();
            }

            return res;
        }
        public override object Clone()
        {
            return new Teacher(Name, Degree, new List<Student>(Students));
        }

        public override void Input(string[] args)
        {
            Name = args[0];
            Degree = args[1];
        }

        public override void OutPut(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }

        public override bool Equals(object obj)
        {
            var teacher = obj as Teacher;
            return teacher != null &&
                   base.Equals(obj) &&
                   EqualityComparer<string>.Default.Equals(Degree, teacher.Degree);
        }

        public override int GetHashCode()
        {
            var hashCode = 466891968;
            hashCode = (hashCode * -1521134295) + base.GetHashCode();           
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Degree);
            return hashCode;
        }
    }
}
