using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Service.Models.Repository
{
   public class AddressRepo : Repository<AddressModel>
    {
        public AddressRepo(DbContext context) : base(context)
        {
        }
    }
}
