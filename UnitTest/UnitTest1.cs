using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonStudentTeacher;
///Створити
/*
 1. Тести для класу Person
    -конструктор
    -Equals
    -GetHashCode
    -ToString
 2. Тести для класу Student
    -конструктор
    -Equals
    -GetHashCode
    -OutPut
 3. Тести для класу Teacher
    -конструктор
    -Equals
    -GetHashCode
    -OutPut
 4. SetStudents, ReadPersons, CloneList
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

        //Tests for Student class
        [TestMethod]
        public void StudentConstructorTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            string expected = "Alex Pmi-32 KlakovichLM";
            string actual = st.Name + " " + st.Group + " " + st.Teacher;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void StudentEqualsTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            Student s2 = new Student("Alex", "Pmi-32", "KlakovichLM");
            bool expected = true;
            bool actual = st.Equals(s2);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void StudentGetHashCodeTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            int expected = 579429062;
            int actual = st.GetHashCode();
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void StudentToStringTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            string expected = "Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = st.ToString();
            Assert.AreEqual(actual, expected);
        }

        //Tests for Teacher class
        [TestMethod]
        public void TeacherConstructorTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> l = new List<Student> {st};            
            Teacher teacher = new Teacher("KlakovichLM", "doctor", l);
            string expected = "KlakovichLM doctor Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = teacher.Name + " " + teacher.Degree + " " + teacher.Students[0].ToString();
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TeacherEqualsTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> l = new List<Student> { st };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", l);
            Teacher teacher2 = new Teacher("KlakovichLM", "doctor", l);

            bool expected = true;
            bool actual = teacher.Equals(teacher2);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TeacherGetHashCodeTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> l = new List<Student> { st };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", l);
            int expected = -1689496395;
            int actual = teacher.GetHashCode();
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TeacherToStringTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> l = new List<Student> { st };
            Teacher teacher = new Teacher("KlakovichLM", "doctor", l);
            string expected = "KlakovichLM doctor Students:\r\nAlex Pmi-32 Teacher:  KlakovichLM";
            string actual = teacher.ToString();
            Assert.AreEqual(actual, expected);
        }

        //SetStudents, ReadPersons, CloneList
        [TestMethod]
        public void SetStudentsTest()
        {
            string actual = "Alex Pmi-32 Teacher:  KlakovichLM";
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Person> l = new List<Person>();
            l.Add(st);
            Teacher teacher = new Teacher();            
            ExceptionsHandler.SetStudents(ref teacher, ref l);            
            string expected = "Alex Pmi-32 Teacher:  KlakovichLM";
            //string actual1 = teacher.Students[0].ToString();            
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ReadPersonsTest()
        {         
            List<Person> l = new List<Person> ();            
            ExceptionsHandler.ReadPersons("test.txt", l);
            string expected = "Hans";            
            string actual = l[0].Name;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CloneListTest()
        {
            Student st = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Person> l = new List<Person>();
            l.Add(st);
            ExceptionsHandler.CloneList(ref l);
            int expected = 2;
            int actual = l.Capacity;
            Assert.AreNotEqual(actual, expected);
        }
    }
}
