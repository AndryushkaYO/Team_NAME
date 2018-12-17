using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Wpf_Service.Models.Contexts;
using Wpf_Service.Orders;

namespace Wpf_Service.Models.Repository
{
   public class OrderRepo : Repository<Order>
   {
       private OrderDbContext _context;
        public OrderRepo(DbContext context) : base(context)
        {
            _context = (OrderDbContext)context;
        }

        public override IEnumerable<Order> GetAll()
        {
            return _context.Orders.
                Include(s=>s.GoodsData)
                .ToList();
        }

       
    }
}
