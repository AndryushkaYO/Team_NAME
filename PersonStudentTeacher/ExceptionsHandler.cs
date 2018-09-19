using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace PersonStudentTeacher
{
    class ExceptionsHandler
    {
        static void SetStudents(Teacher tc, List<Person> pers)
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
                    SetStudents(teacher, pers);
                }
            }
        }

        public static List<Person> CloneList(ref List<Person> Persons)
        {
            List<Person> ClonedList = new List<Person>();
            foreach (Person person in Persons)
            {
                ClonedList.Add((Person)person.Clone());
            }

            return ClonedList;
        }

        public static void WriteCloned(List<Person> pers)
        {
            List<Person> clonedPers = CloneList(ref pers);
            using (StreamWriter sw = new StreamWriter("ClonedOutput.txt"))
            {
                foreach (var per in clonedPers)
                {
                    sw.WriteLine(per.ToString());
                }
            }
        }
        static public void Do()
        {
            List<Person> pers = new List<Person>();
            ReadPersons("Persons.txt", pers);
            WriteCloned(pers);

            Console.WriteLine("Unique persons:  ");
            //Uses Equals and GetHashcode
            IEnumerable<Person> uniquePers = pers.Distinct().ToList();
            foreach (var per in uniquePers)
            {
                Console.WriteLine(per.ToString());
            }

            IEnumerable<Student> students = from per in uniquePers where per is Student select (Student)per;
            Console.WriteLine("Number of students:  " + students.Count());

            IEnumerable<Teacher> teachers = from teach in uniquePers where teach is Teacher select (Teacher)teach;
            Console.WriteLine("Number of teachers:  " + teachers.Count());
            Console.ReadLine();
        }
    }
}
