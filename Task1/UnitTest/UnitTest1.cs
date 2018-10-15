using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonStudentTeacher;
///Tasks:
/*
 1. Тести для класу Person
    -конструктор
    -Equals
    -GetHashCode
    -ToString
    -Clone
    -Input
    -Print
 2. Тести для класу Student
    -конструктор
    -Equals
    -GetHashCode
    -Print 
 3. Тести для класу Teacher
    -конструктор
    -Equals
    -GetHashCode
    -Print 
    -Clone
 4. SetStudents, ReadPersons, CloneList, WriteCloned
    
 */

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        //Tests for Persons class
        [TestMethod]
        public void PersonConstructorTest()
        {
            Person man = new Person("Alex");
            string expected = "Alex";
            string actual = man.Name;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PersonEqualsTest()
        {
            Person man = new Person("Alex");
            Person woman = new Person("Erza");
            bool expected = false;
            bool actual = man.Equals(woman);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PersonGetHashCodeTest()
        {
            Person man = new Person("Alex");
            int expected = 59779942;
            int actual = man.GetHashCode();
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void PersonToStringTest()
        {
            Person man = new Person("Alex");
            string expected = "Alex";
            string actual = man.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PersonCloneTest()
        {
            Person man = new Person("Alex");
            Exception exception = null;
            try
            {
                object boy = man.Clone();
            }

            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);

        }

        [TestMethod]
        public void PersonInputTest()
        {
            Person man = new Person("Alex");
            string[] new_name = { "Levi" };
            man.Input(new_name);
            string expected = "Levi";
            string actual = man.Name;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PersonPrintTest()
        {
            Person man = new Person("Alex");
            using (StreamWriter sw = new StreamWriter("TestPrint.txt"))
            {
                man.Print(sw);
            }
            //  string path = System.IO.Directory.GetCurrentDirectory().Replace("bin\\Debug", "TestPrint.txt");
            string path = "TestPrint.txt";
            string expected = man.ToString();
            string actual;
            using (StreamReader sr = new StreamReader(path))
            {
                actual = sr.ReadLine();
            }
            Assert.AreEqual(actual, expected);
        }

        //Tests for Student class
        [TestMethod]
        public void StudentConstructorTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            string expected = "Alex Pmi-32 KlakovichLM";
            string actual = student.Name + " " + student.Group + " " + student.Teacher;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void StudentEqualsTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            Student student2 = new Student("Alex", "Pmi-32", "KlakovichLM");
            bool expected = true;
            bool actual = student.Equals(student2);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void StudentGetHashCodeTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            int expected = 579429062;
            int actual = student.GetHashCode();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void StudentToStringTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            string expected = "Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = student.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void StudentPrintTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            using (StreamWriter sw = new StreamWriter("TestPrint.txt"))
            {
                student.Print(sw);
            }
            //  string path = System.IO.Directory.GetCurrentDirectory().Replace("bin\\Debug", "TestPrint.txt");
            string path = "TestPrint.txt";
            string expected = student.ToString();
            string actual;
            using (StreamReader sr = new StreamReader(path))
            {
                actual = sr.ReadLine();
            }
            Assert.AreEqual(actual, expected);
        }

        //Tests for Teacher class
        [TestMethod]
        public void TeacherConstructorTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> { student };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            string expected = "KlakovichLM doctor Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = teacher.Name + " " + teacher.Degree + " " + teacher.Students[0].ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TeacherEqualsTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> { student };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            Teacher teacher2 = new Teacher("KlakovichLM", "doctor", students_list);
            bool expected = true;
            bool actual = teacher.Equals(teacher2);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TeacherGetHashCodeTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> { student };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            int expected = -1689496395;
            int actual = teacher.GetHashCode();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TeacherToStringTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> { student };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            string expected = "KlakovichLM doctor Students:\r\nAlex Pmi-32 Teacher:  KlakovichLM";
            string actual = teacher.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TeacherCloneTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> { student };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            object obj = teacher.Clone();
            Teacher lector = (Teacher)obj;
            Assert.AreEqual(teacher, lector);
        }

        [TestMethod]
        public void TeacherPrintTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> { student };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            using (StreamWriter sw = new StreamWriter("TestPrint.txt"))
            {
                teacher.Print(sw);
            }
            //  string path = System.IO.Directory.GetCurrentDirectory().Replace("bin\\Debug", "TestPrint.txt");
            string path = "TestPrint.txt";
            string expected = "KlakovichLM doctor Students:Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    actual += sr.ReadLine();
                }
            }
            Assert.AreEqual(actual, expected);
        }

        //SetStudents, ReadPersons, CloneList
        [TestMethod]
        public void SetStudentsTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Person> students_list = new List<Person>();
            students_list.Add(student);
            Teacher teacher = new Teacher();
            teacher.Name = "KlakovichLM";
            Task.SetStudents(ref teacher, ref students_list);
            string expected = "Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = teacher.Students[0].ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ReadPersonsTest()
        {
            List<Person> students_list = new List<Person>();
            Task.ReadPersons("test.txt", students_list);
            string expected = "Hans";
            string actual = students_list[0].Name;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CloneListTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Person> students_list = new List<Person>();
            students_list.Add(student);
            Task.CloneList(ref students_list);
            int expected = 4;
            int actual = students_list.Capacity;
            Assert.AreEqual(actual, expected);
        }


        [TestMethod]
        public void WriteClonedTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Person> students_list = new List<Person>();
            students_list.Add(student);
            Task.WriteCloned(students_list);
            string path = "ClonedOutput.txt";
            string expected = "Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    actual += sr.ReadLine();
                }
            }
            Assert.AreEqual(actual, expected);
        }


    }
}
