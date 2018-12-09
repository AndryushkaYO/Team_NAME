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

        [TestMethod]
        public void OrderTest()
        {
            ProductModel product = new ProductModel(23443, 2);
            AddressModel address = new AddressModel("Lviv", "Medova", 65);
            ClientModel client = new ClientModel("Andri", "Yovbak", "andri@gmai.com", "066-26-39-014", address);
            StoreModel store = new StoreModel("MeowShop", address);
            Order order = new Order(12, client, store, product);
            Assert.AreEqual(order.ClientData.FirstName, "Andri");
            Assert.AreEqual(order.ClientData.LastName, "Yovbak");
            Assert.AreEqual(order.ClientData.Email, "andri@gmai.com");
            Assert.AreEqual(order.ClientData.PhoneNumber, "066-26-39-014");
            Assert.AreEqual(order.ClientData.AddressModel.City, "Lviv");
            Assert.AreEqual(order.ClientData.AddressModel.Street, "Medova");
            Assert.AreEqual(order.ClientData.AddressModel.BuildingNumber, (UInt32)65);
            Assert.AreEqual(order.GoodsData.Code, (uint)23443);
            Assert.AreEqual(order.GoodsData.Weight, 2);
            Assert.AreEqual(order.ShopData.Name, "MeowShop");
            Assert.AreEqual(order.ShopData.AddressModel.City, "Lviv");
            Assert.AreEqual(order.ShopData.AddressModel.Street, "Medova");
            Assert.AreEqual(order.ShopData.AddressModel.BuildingNumber, (UInt32)65);

            XElement q = new XElement(
                "Order",
                new XAttribute("Id", 1),
                client.ToXml(),
                product.ToXml(),
                store.ToXml());

            XElement z = order.ToXml();
            Assert.AreNotEqual(q, z);
        }

        [TestMethod]
        public void OrderStorageTest()
        {
            string path = "storage.xml";
            OrdersStorage storage = new OrdersStorage(path);
            storage.CreateIfNotExists();
            Assert.IsTrue(storage.StorageExists());
            storage.DeleteIfExists();
            Assert.IsFalse(storage.StorageExists());
        }
    }
}
