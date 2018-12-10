using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Service.Models.Repository;

namespace Wpf_Service.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AddressModel> Addressses { get; }
        IRepository<ClientModel> Clients { get; }
        IRepository<ProductModel> Products { get; }
        IRepository<StoreModel> Stores { get; }
        IRepository<Orders.Order> Orders { get; }       

        Task<int> Complete();
    }
}
