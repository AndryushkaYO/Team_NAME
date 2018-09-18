using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentTeacher
{
    class Teacher : Person
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public string Degree { get; set; }
        public Teacher(string name, string degree, List<Student> students) : base(name)
        {
            Students = students;
            Degree = degree;
        }

        public Teacher()
        {
        }

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
            hashCode = hashCode * -1521134295 + base.GetHashCode();           
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Degree);
            return hashCode;
        }
    }
}
//Варіант 7.
//1) Створити ієрархію класів Person-Student-Teacher.В кожного Teacher повинен бути
//список Students, якими він керує, а в кожного Student - Teacher, який ним керує.В
//кожному класі повинні бути віртуальні функції Input() та Print() і перевизначена функція
//ToString(). Для класів Person-Student-Teacher реалізувати Equals() та GetHashCode().
//2) В текстовому файлі задано дані про студентів та викладачів.Ввести дані в колекцію Person.
//Проілюструвати роботу Clone на даній колекції – створити колекцію
//клонованих об’єктів.Вивести результат у файл.
//3) Порахувати скільки в колекції є студентів і скільки викладачів.Продемонструвати
//роботу Equals() – утворивши з даної унікальну колекцію Person без повторів.
//4)Перехоплення винятків.
//5) Використання Linq
//6) Весь код повинен бути покритий юніт тестами