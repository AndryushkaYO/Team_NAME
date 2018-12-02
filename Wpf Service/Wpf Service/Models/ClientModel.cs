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
    public class ClientModel
    {
		[XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlAttribute]
        public string Email { get; set; }

        [XmlAttribute]
        public string PhoneNumber { get; set; }

        public AddressModel AddressModel { get; set; }

        public ClientModel()
        {
            AddressModel = new AddressModel();
        }

        public ClientModel(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            AddressModel clientAddress)
        {
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim();
            PhoneNumber = phoneNumber.Trim();
            AddressModel = clientAddress;
        }

        public ClientModel(XmlNode source)
        {
            if (source == null)
            {
                throw new NullReferenceException("can't parse ClientModel");
            }

            if (source.Attributes == null)
            {
                throw new NullReferenceException("can't parse ClientModel attributes");
            }

            FirstName = source.Attributes["FirstName"].Value;
            LastName = source.Attributes["LastName"].Value;
            Email = source.Attributes["Email"].Value;
            PhoneNumber = source.Attributes["PhoneNumber"].Value;
            var addressNode = source.SelectSingleNode("AddressModel");
            if (addressNode == null)
            {
                throw new NullReferenceException("can't parse ClientModel.AddressModel");
            }

            AddressModel = new AddressModel(addressNode.Attributes);
        }

        public XElement ToXml()
        {
            return new XElement(
                "ClientData",
                new XAttribute("FirstName", FirstName),
                new XAttribute("LastName", LastName),
                new XAttribute("Email", Email),
                new XAttribute("PhoneNumber", PhoneNumber),
                AddressModel.ToXml());
        }
    }
}
