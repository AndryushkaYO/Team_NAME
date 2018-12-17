using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Service.Models.Repository
{
    public class ClientRepo : Repository<ClientModel>
    {
        public ClientRepo(DbContext context) : base(context)
        {
        }
    }
}
