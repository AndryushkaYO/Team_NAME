using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Wpf_Service.Models
{

  
    public class StoreModel
    {
        [Key]
        public string Name { get; set; }

        public string AddressKey { get; set; }

        public virtual string OrderId { get; set; }

        [ForeignKey("AddressKey")]
        public virtual AddressModel AddressModel { get; set; }

        public StoreModel()
        {
            AddressModel = new AddressModel();
        }


        public StoreModel(string name, AddressModel shopAddressModel,string orderId)
        {
            Name = name.Trim();
            AddressModel = shopAddressModel;
            AddressKey = AddressModel.getKey();
            OrderId = orderId;
        }
    }
}
