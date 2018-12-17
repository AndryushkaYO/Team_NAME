﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Wpf_Service.Models
{
    public class AddressModel
    {
        [Key]
        public string Id { get;  set; }

        public string City { get; set; }
    
        public string Street { get; set; }

        public uint BuildingNumber { get; set; }

        public virtual string ClientId { get; set; }

        public AddressModel()
        {
        }

        public AddressModel(string city, string street, uint buildingNumber,string client = null)
        {
            City = city.Trim();
            Street = street.Trim();
            BuildingNumber = buildingNumber;
            Id = getKey();
            ClientId = client;
        }

        public string getKey()
        {
            return City + Street + BuildingNumber;
        }

   
    }
}
