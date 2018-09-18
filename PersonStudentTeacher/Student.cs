﻿namespace PersonStudentTeacher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Student : Person
    {
       

        public Student() : base()
        {
        }

        public Student(string name, string group, string teacher) : base(name)
        {
            Teacher = teacher;
            Group = group;
        }
        public string Teacher { get; set; }
        public string Group { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Group} Teacher:  {Teacher}";
        }


        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   base.Equals(obj) &&
                   EqualityComparer<string>.Default.Equals(Teacher, student.Teacher) &&
                   Group == student.Group;
        }

        public override int GetHashCode()
        {
            var hashCode = 398198191;
            hashCode = (hashCode * -1521134295) + base.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Teacher);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Group);
            return hashCode;
        }

        public override object Clone()
        {
            return new Student(Name, Group, Teacher);
        }

        public override void Input(string[] args)
        {
            Name = args[0];
            Group = args[1];
            Teacher = args[2];
        }

        public override void OutPut(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }

       
    }
}
