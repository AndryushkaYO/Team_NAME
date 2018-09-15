using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStudentTeacher
{
    class Program
    {
        static void setStudents(Teacher tc, List<Person> pers)
        {
            foreach (var per in pers)
            {
                if (per is Student && ((Student)per).Teacher == tc.Name)
                {
                    tc.Students.Add((Student)per);
                }
            }
        }

        public static void ReadPersons(string fileName, List<Person> pers)
        {
            string path = System.IO.Directory.GetCurrentDirectory().Replace("bin\\Debug", fileName);
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    string[] args = line.Split(' ');
                    Person newPers = null;
                    switch (args.Length)
                    {
                        case 3:
                            newPers = new Student();
                            break;
                        case 2:
                            newPers = new Teacher();
                            break;
                        default:
                            break;
                    }

                    if (newPers != null)
                    {
                        newPers.Input(args);
                        pers.Add(newPers);
                    }
                }
            }

            foreach (var per in pers)
            {
                if (per is Teacher teacher)
                {
                    setStudents(teacher, pers);
                }
            }
        }

        static void Main(string[] args)
        {
            List<Person> pers = new List<Person>();
            ReadPersons("Persons.txt", pers);
            foreach (var per in pers)
            {
                Console.WriteLine(per.ToString());

            }
        }
    }
}
