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

        [TestMethod]
        public void StoreModelTest()
        {
            AddressModel address = new AddressModel("Lviv", "Medova", 65);
            StoreModel store = new StoreModel("MeowShop", address);
            Assert.AreEqual(store.Name, "MeowShop");
            Assert.AreEqual(store.AddressModel.City, "Lviv");
            Assert.AreEqual(store.AddressModel.Street, "Medova");
            Assert.AreEqual(store.AddressModel.BuildingNumber, (UInt32)65);

            XElement x = new XElement(
                "ShopData",
                new XAttribute("Name", "CoShop"),
                address.ToXml());
            XElement z = store.ToXml();
            Assert.AreNotEqual(x, z);
        }

        [TestMethod]
        public void ProductModelTest()
        {
            ProductModel product = new ProductModel(23443, 2);
            Assert.AreEqual(product.Code, (uint)23443);
            Assert.AreEqual(product.Weight, 2);

            XElement x = new XElement(
                 "GoodsData",
                 new XAttribute("Code", 12232),
                 new XAttribute("Weight", 1));
            XElement z = product.ToXml();
            Assert.AreNotEqual(x, z);
        }
    }
}
