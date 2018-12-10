using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Service.Models.Contexts
{
    public class OrderDbContext : DbContext
    {
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<ClientModel> Clients { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<StoreModel> Stores { get; set; }
        public virtual DbSet<Orders.Order> Orders { get; set; }

        public OrderDbContext() : base("OrdersDb")
        {
            Database.CreateIfNotExists();
        }
    }
}
