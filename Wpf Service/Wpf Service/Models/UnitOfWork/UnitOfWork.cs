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

        public IRepository<AddressModel> Addressses { get; }
        public IRepository<ClientModel> Clients { get; }
        public IRepository<ProductModel> Products { get; }
        public IRepository<StoreModel> Stores { get; }
        public IRepository<Orders.Order> Orders { get; }


        public UnitOfWork(OrderDbContext context)
        {
            _context = context;
            Addressses = new Repository<AddressModel>(_context);
            Clients = new Repository<ClientModel>(_context);
            Products = new Repository<ProductModel>(_context);
            Stores = new Repository<StoreModel>(_context);
            Orders = new Repository<Orders.Order>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();          
        }      


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();         
        }
    }
}
