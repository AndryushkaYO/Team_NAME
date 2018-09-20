using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonStudentTeacher;
///Tasks:
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

        //Tests for Teacher class
        [TestMethod]
        public void TeacherConstructorTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> {student};            
            Teacher teacher = new Teacher("KlakovichLM", "doctor", students_list);
            string expected = "KlakovichLM doctor Alex Pmi-32 Teacher:  KlakovichLM";
            string actual = teacher.Name + " " + teacher.Degree + " " + teacher.Students[0].ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TeacherEqualsTest()
        {
            Student student = new Student("Alex", "Pmi-32", "KlakovichLM");
            List<Student> students_list = new List<Student> {student};
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
            List<Person> students_list = new List<Person> ();            
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
            int expected = 2;
            int actual = students_list.Capacity;
            Assert.AreNotEqual(actual, expected);
        }
    }
}
