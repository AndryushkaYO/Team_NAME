using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Wpf_Service.Models
{
    [Serializable]
    class AddressModel
    {

        [XmlAttribute]
        public string City { get; set; }

        [XmlAttribute]
        public string Street { get; set; }

        [XmlAttribute]
        public uint BuildingNumber { get; set; }

        public AddressModel()
        {
        }

        public AddressModel(string city, string street, uint buildingNumber)
        {
            City = city.Trim();
            Street = street.Trim();
            BuildingNumber = buildingNumber;
        }

        public AddressModel(XmlAttributeCollection source)
        {
            if (source == null)
            {
                throw new NullReferenceException("can't parse AddressModel");
            }

            City = source["City"].Value;
            Street = source["Street"].Value;
            if (!uint.TryParse(source["BuildingNumber"].Value, out var buidingNumber))
            {
                throw new InvalidDataException("AddressModel.BuildingNumber must be of type 'uint'");
            }

            BuildingNumber = buidingNumber;
        }

        public XElement ToXml()
        {
            return new XElement(
                "AddressModel",
                new XAttribute("City", City),
                new XAttribute("Street", Street),
                new XAttribute("BuildingNumber", BuildingNumber));
        }
    }
}
