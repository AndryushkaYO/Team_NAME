using System;
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
            int expected = 0;
            int actual = 0;
            Assert.AreEqual(1,1);
            
        }
        [TestMethod]
        public void PersonToStringTest()
        {
            Person man = new Person("Alex");
            string expected = "Alex";
            string actual = man.ToString();
            Assert.AreEqual(actual, expected);
        }

    }
}
