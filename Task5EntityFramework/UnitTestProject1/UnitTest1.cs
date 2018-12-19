using System;
using System.Data.Entity;
using CargoDelivery.Classes;
using CargoDelivery.Classes.OrderData;
using CargoDelivery.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOrderTest()
        {
            var mockSet = new Mock<DbSet<Order>>();
            var mockContext = new Mock<OrderContext>();


            mockContext.Setup(m => m.Set<Order>()).Returns(mockSet.Object);


            Order toSeed = new Order
            {
                ClientData = new ClientData
                {
                    FirstName = "Leroy",
                    LastName = "Jenkins",
                    Email = "damnsongmail",
                    PhoneNumber = "69696",
                    Address = new Address
                    {

                        City = "Kansas",
                        Street = "Booze",
                        BuildingNumber = 69
                    }
                },
                ShopData =
                   new ShopData
                   {
                       Name = "GetRect",
                       Address = new Address
                       {
                           City = "Kansas",
                           Street = "ShposStreet",
                           BuildingNumber = 123
                       }
                   },
                GoodsData = new GoodsData
                {
                    Code = 34,
                    Id = 4,
                    Weight = 23
                }
            };
            mockSet.Setup(m => m.Remove(toSeed)).Returns(toSeed);
            var repo = new GenericRepository<Order>(mockContext.Object);
      



            repo.Insert(toSeed);
            repo.Save();
            mockSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AddAddressTest()
        {
            var mockSet = new Mock<DbSet<Address>>();
            var mockContext = new Mock<OrderContext>();

            mockContext.Setup(m => m.Set<Address>()).Returns(mockSet.Object);

            Address toSeed = new Address
            {

                City = "Kansas",
                Street = "Booze",
                BuildingNumber = 69
            };

            var repo = new GenericRepository<Address>(mockContext.Object);



            repo.Insert(toSeed);
            repo.Save();
            mockSet.Verify(m => m.Add(It.IsAny<Address>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void RemoveOrderTest()
        {
            var mockSet = new Mock<DbSet<Order>>();
            var mockContext = new Mock<OrderContext>();

            mockContext.Setup(m => m.Set<Order>()).Returns(mockSet.Object);


            Order toSeed = new Order
            {
                ClientData = new ClientData
                {
                    FirstName = "Leroy",
                    LastName = "Jenkins",
                    Email = "damnsongmail",
                    PhoneNumber = "69696",
                    Address = new Address
                    {

                        City = "Kansas",
                        Street = "Booze",
                        BuildingNumber = 69
                    }
                },
                ShopData =
                   new ShopData
                   {
                       Name = "GetRect",
                       Address = new Address
                       {
                           City = "Kansas",
                           Street = "ShposStreet",
                           BuildingNumber = 123
                       }
                   },
                GoodsData = new GoodsData
                {
                    Code = 34,
                    Id = 4,
                    Weight = 23
                }
            };
            var repo = new GenericRepository<Order>(mockContext.Object);



            repo.Delete(toSeed);
            repo.Save();
            mockSet.Verify(m => m.Remove(It.IsAny<Order>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [TestMethod]
        public void FindOrderTest()
        {
            var mockSet = new Mock<DbSet<Order>>();
          
            var mockContext = new Mock<OrderContext>();

            mockContext.Setup(m => m.Set<Order>()).Returns(mockSet.Object);
            mockSet.Setup(m => m.Find("someId")).Returns(new Order());

            var repo = new GenericRepository<Order>(mockContext.Object);

            repo.GetById("someId");
            mockSet.Verify(m => m.Find("someId"), Times.Once());
        }
    }
}
