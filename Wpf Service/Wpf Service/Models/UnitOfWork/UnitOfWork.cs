using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Service.Models.Contexts;
using Wpf_Service.Models.Repository;
using Wpf_Service.Orders;

namespace Wpf_Service.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _context;

        public AddressRepo Addressses { get; }
        public ClientRepo Clients { get; }
        public ProductRepo Products { get; }
        public StoreRepo Stores { get; }
        public OrderRepo Orders { get; }


        public UnitOfWork(OrderDbContext context)
        {
            _context = context;
            Addressses = new AddressRepo(_context);
            Clients = new ClientRepo(_context);
            Products = new ProductRepo(_context);
            Stores = new StoreRepo(_context);
            Orders = new OrderRepo(_context);
        }

        public void Dispose()
        {
            _context.Dispose();          
        }      


        public  int Complete()
        {
            return  _context.SaveChanges();         
        }
    }
}
