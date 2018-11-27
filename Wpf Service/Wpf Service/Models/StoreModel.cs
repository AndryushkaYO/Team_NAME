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

    [Serializable]
    public class StoreModel
    {

        public string Name { get; set; }

        public AddressModel AddressModel { get; set; }


        public StoreModel()
        {
            AddressModel = new AddressModel();
        }


        public StoreModel(string name, AddressModel shopAddressModel)
        {
            Name = name.Trim();
            AddressModel = shopAddressModel;
        }

        public StoreModel(XmlNode source)
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
