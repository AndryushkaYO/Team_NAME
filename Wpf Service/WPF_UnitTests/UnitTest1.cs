using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf_Service;
using Wpf_Service.Models;
using Wpf_Service.Orders;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WPF_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddressModelTest()
        {
            AddressModel address = new AddressModel("Lviv", "Medova", 65);
            Assert.AreEqual(address.City, "Lviv");
            Assert.AreEqual(address.Street, "Medova");
            Assert.AreEqual(address.BuildingNumber, (UInt32)65);

            XElement x = new XElement(
                "AddressModel",
                new XAttribute("City", "Kiev"),
                new XAttribute("Street", "Medova"),
                new XAttribute("BuildingNumber", 98));

            XElement z = address.ToXml();
            Assert.AreNotEqual(z, x);
        }

        [TestMethod]
        public void ClientModelTest()
        {
            AddressModel address = new AddressModel("Lviv", "Medova", 65);
            ClientModel client = new ClientModel("Andri", "Yovbak", "andri@gmai.com", "066-26-39-014", address);
            Assert.AreEqual(client.FirstName, "Andri");
            Assert.AreEqual(client.LastName, "Yovbak");
            Assert.AreEqual(client.Email, "andri@gmai.com");
            Assert.AreEqual(client.PhoneNumber, "066-26-39-014");
            Assert.AreEqual(client.AddressModel.City, "Lviv");
            Assert.AreEqual(client.AddressModel.Street, "Medova");
            Assert.AreEqual(client.AddressModel.BuildingNumber, (UInt32)65);

            XElement x = new XElement(
                "ClientData",
                new XAttribute("FirstName", "Oleg"),
                new XAttribute("LastName", "Datskiv"),
                new XAttribute("Email", "o@maill.c"),
                new XAttribute("PhoneNumber", "099-45-56-345"),
                address.ToXml());
            XElement z = client.ToXml();
            Assert.AreNotEqual(x, z);
        }
    }
}
