using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Wpf_Service.Models
{
    class StoreModel
    {
        [Serializable]
        public class ShopData
        {

            public string Name { get; set; }

            public AddressModel AddressModel { get; set; }


            public ShopData()
            {
                AddressModel = new AddressModel();
            }


            public ShopData(string name, AddressModel shopAddressModel)
            {
                Name = name.Trim();
                AddressModel = shopAddressModel;
            }

            public ShopData(XmlNode source)
            {

                var attributes = source.Attributes;

                Name = attributes["Name"].Value;
                var AddressModelElement = source.SelectSingleNode("AddressModel");
                AddressModel = new AddressModel(AddressModelElement.Attributes);
            }

            public XElement ToXml()
            {
                return new XElement(
                    "ShopData",
                    new XAttribute("Name", Name),
                    AddressModel.ToXml());
            }
        }
    }
}
