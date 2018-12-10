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

        }

        [TestMethod]
        public void ProductModelTest()
        {
            ProductModel product = new ProductModel(23443, 2);
            Assert.AreEqual(product.Code, (uint)23443);
            Assert.AreEqual(product.Weight, 2);

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
        }
      
    }
}
