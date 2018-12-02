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
    public class ProductModel
    {
        [XmlAttribute]
        public uint Code { get; set; }

        [XmlAttribute]
        public double Weight { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(uint code, double weight)
        {
            Code = code;
            Weight = weight;
        }

        public ProductModel(XmlAttributeCollection source)
        {
            if (source == null)
            {
                throw new NullReferenceException("can't parse ProductModel");
            }

            if (!uint.TryParse(source["Code"].Value, out var code))
            {
                throw new InvalidDataException("ProductModel.Code must be of type 'uint'");
            }

            Code = code;
            if (!double.TryParse(source["Weight"].Value, out var weight))
            {
                throw new InvalidDataException("ProductModel.Weight must be of type 'uint'");
            }

            Weight = weight;
        }

        public XElement ToXml()
        {
            return new XElement(
                "GoodsData",
                new XAttribute("Code", Code),
                new XAttribute("Weight", Weight));
        }
    }
}
