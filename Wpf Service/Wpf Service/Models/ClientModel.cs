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
    
  
    public class ClientModel
    {
        [Key]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string AddressKey { get; set; }
        [ForeignKey("AddressKey")]
        public virtual AddressModel AddressModel { get; set; }

        public virtual string OrderId { get; set; }

        public ClientModel()
        {
            AddressModel = new AddressModel();
        }

        public ClientModel(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            AddressModel clientAddress,
            string orderId)
        {
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim();
            PhoneNumber = phoneNumber.Trim();
            AddressModel = clientAddress;
            Id = getKey();
            AddressKey = AddressModel.getKey();
            OrderId = orderId;
        }

        public string getKey()
        {
            return FirstName + LastName + PhoneNumber[0];
            
        }
       
    
}
}
