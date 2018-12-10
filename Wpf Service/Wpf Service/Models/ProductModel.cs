using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Wpf_Service.Models
{
    public class ProductModel
    {
        [Key]
        public string Code { get; set; }

        public double Weight { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(uint code, double weight)
        {
            Code = code.ToString();
            Weight = weight;
        }

      
      
    }
}
