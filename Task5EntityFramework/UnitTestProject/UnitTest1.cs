using CargoDelivery.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using CargoDelivery.Classes.OrderData;
using CargoDelivery.DAL;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOrderTest()
        {
            var mockSet = new Mock<DbSet<Order>>();
            var mockSetAddres = new Mock<DbSet<Address>>();
            var mockSetClient = new Mock<DbSet<ClientData>>();
            var mockSetGoods = new Mock<DbSet<GoodsData>>();
            var mockSetShop = new Mock<DbSet<ShopData>>();
            var mockContext = new Mock<OrderContext>();

            mockContext.Setup(m => m.Set<Order>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<Address>()).Returns(mockSetAddres.Object);
            mockContext.Setup(m => m.Set<ClientData>()).Returns(mockSetClient.Object);
            mockContext.Setup(m => m.Set<GoodsData>()).Returns(mockSetGoods.Object);
            mockContext.Setup(m => m.Set<ShopData>()).Returns(mockSetShop.Object);
           
            Order toSeed = new Order { 
                ClientData = new ClientData{
                   FirstName = "Leroy",
                    LastName = "Jenkins",
                    Email = "damnsongmail",
                    PhoneNumber = "69696",
               Address = new Address
               {

               City = "Kansas",
                   Street = "Booze",
                   BuildingNumber = 69}},
                ShopData = 
                   new ShopData{
                Name = "GetRect",
                 Address = new Address
                       {
                       City = "Kansas",
                           Street = "ShposStreet",
                           BuildingNumber = 123
                        }},
                GoodsData = new GoodsData
                {
                    Code = 34,
                    Id = 4,
                    Weight = 23
                }};
            var repo = new GenericRepository<Order>();
            repo.DbSet = mockSet.Object;
            repo.Context = mockContext.Object;

            //mockContext.Object.Orders = mockSet.Object;

            //repo.Insert(toSeed);
            //repo.Save();
            //mockSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
