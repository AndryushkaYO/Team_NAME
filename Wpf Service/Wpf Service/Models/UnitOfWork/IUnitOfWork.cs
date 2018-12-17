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
        AddressRepo Addressses { get; }
        ClientRepo Clients { get; }
        ProductRepo Products { get; }
        StoreRepo Stores { get; }
        OrderRepo Orders { get; }

        int Complete();
    }
}
