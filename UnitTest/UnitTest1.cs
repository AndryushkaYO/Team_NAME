using System;
using System.Collections.Generic;
using AdoDotNet.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        string database = "Integrated Security=true; Initial Catalog=NORTHWND_TEST; server=DESKTOP-EFLFJL0";
        private Task ts = new Task();
        [TestMethod]
        public void Query18Test()
        {
            ts.ConnectToDatabase();
            var res = ts._db.ExecQuery(Queries.Data[0], out var columns);
            Assert.AreEqual("Annette Roulet", res[0][0]);
            //Assert.AreEqual("Roulet", res[0][1]);
            Assert.AreEqual("Carine Schmitt", res[1][0]);
            //Assert.AreEqual("", res[1][1]);
            Assert.AreEqual("Daniel Tonini", res[2][0]);
            //Assert.AreEqual("Tonini", res[2][1]);
            Assert.AreEqual("Dominique Perrier", res[3][0]);
            //Assert.AreEqual("Perrier", res[3][1]);
            ts.DisconnectFromDatabase();
        }
        [TestMethod]
        public void Query21Test()
        {
            ts.ConnectToDatabase();
            var res = ts._db.ExecQuery(Queries.Data[3], out var columns);
            Assert.AreEqual("Karin Josephs", res[0][0]);            
            Assert.AreEqual("9", res[0][1]);
            Assert.AreEqual("167,4000", res[0][2]);
            Assert.AreEqual("Philip Cramer", res[1][0]);
            
            Assert.AreEqual("9", res[1][1]);
            Assert.AreEqual("167,4000", res[1][2]);
            Assert.AreEqual("Pirkko Koskitalo", res[2][0]);
            
            Assert.AreEqual("10", res[2][1]);
            Assert.AreEqual("186,0000", res[2][2]);
            ts.DisconnectFromDatabase();
        }
        [TestMethod]
        public void Query25Test()
        {
            ts.ConnectToDatabase();
            var res = ts._db.ExecQuery(Queries.Data[7], out var columns);
            Assert.AreEqual("Finland", res[0][0]);
            Assert.AreEqual("18810,0500", res[0][1]);
            Assert.AreEqual("USA", res[1][0]);
            Assert.AreEqual("245584,6300", res[1][1]);
            Assert.AreEqual("Italy", res[2][0]);
            Assert.AreEqual("15770,1600", res[2][1]);
            Assert.AreEqual("Brazil", res[3][0]);
            Assert.AreEqual("106925,7700", res[3][1]);
            ts.DisconnectFromDatabase();
        }
        [TestMethod]
        public void Query27Test()
        {
            ts.ConnectToDatabase();
            var res = ts._db.ExecQuery(Queries.Data[9], out var columns);
            Assert.AreEqual("Beverages", res[0][0]);
            Assert.AreEqual("102074,3100", res[0][1]);
            Assert.AreEqual("Condiments", res[1][0]);
            Assert.AreEqual("55277,6000", res[1][1]);
            Assert.AreEqual("Confections", res[2][0]);
            Assert.AreEqual("80894,1400", res[2][1]);
            Assert.AreEqual("Dairy Products", res[3][0]);
            Assert.AreEqual("114749,7800", res[3][1]);
            ts.DisconnectFromDatabase();
        }
        [TestMethod]
        public void Query24Test()
        {
            ts.ConnectToDatabase();
            var res = ts._db.ExecQuery(Queries.Data[6], out var columns);
            Assert.AreEqual("Dominique Perrier", res[0][0]);
            
            Assert.AreEqual("Frédérique Citeaux", res[1][0]);
            
            Assert.AreEqual("Laurence Lebihan", res[2][0]);
            
            Assert.AreEqual("Martine Rancé", res[3][0]);
            
            ts.DisconnectFromDatabase();
        }
    }
}
