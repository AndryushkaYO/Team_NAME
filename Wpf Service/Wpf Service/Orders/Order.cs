using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.Xml.Serialization;

using Wpf_Service.Models;

namespace Wpf_Service.Orders
{
    /// <summary>
	/// Represents an order.
	/// </summary>
	[Serializable]
    public class Order
    {
        /// <summary>
        /// Holds an id of the order.
        /// </summary>
        [XmlAttribute]
        public long Id { get; set; }

        /// <summary>
        /// Contains client personal information.
        /// </summary>
        public ClientModel ClientData { get; set; }

        /// <summary>
        /// Represents shop data.
        /// </summary>
        public StoreModel ShopData { get; set; }

        /// <summary>
        /// Holds an information about ordered goods.
        /// </summary>
        public ProductModel GoodsData { get; set; }

        /// <summary>
        /// Constructs order object from xml node source.
        /// </summary>
        /// <param name="source">Xml node object which contains order data.</param>
        /// <exception cref="InvalidDataException">
        /// Throws if xml node attricutes is null or if id value is not long type.
        /// </exception>
        public Order(XmlNode source)
        {
            if (source.Attributes == null)
            {
                throw new InvalidDataException("invalid xml source content");
            }

            if (!long.TryParse(source.Attributes["Id"].Value, out var id))
            {
                throw new InvalidDataException("Order.Id must be of type 'uint'");
            }

            Id = id;
            ClientData = new ClientModel(source.SelectSingleNode("ClientData"));
            ShopData = new StoreModel(source.SelectSingleNode("ShopData"));
            var goodsData = source.SelectSingleNode("GoodsData");
            if (goodsData == null)
            {
                return;
            }

            GoodsData = new ProductModel(goodsData.Attributes);
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="id">An id of the order.</param>
        /// <param name="clientData">Client data object.</param>
        /// <param name="shopData">Shop data object.</param>
        /// <param name="goodsData">Goods data object.</param>
        public Order(long id, ClientModel clientData, StoreModel shopData, ProductModel goodsData)
        {
            Id = id;
            ClientData = clientData;
            ShopData = shopData;
            GoodsData = goodsData;
        }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Order()
        {
            ClientData = new ClientModel();
            ShopData = new StoreModel();
            GoodsData = new ProductModel();
        }

        /// <summary>
        /// Order to Xml object converter.
        /// </summary>
        /// <returns>Order representation as xml element.</returns>
        public XElement ToXml()
        {
            XElement q  = new XElement(
                "Order",
                new XAttribute("Id", Id),
                ClientData.ToXml(),
                GoodsData.ToXml(),
                ShopData.ToXml());
            return q;
        }

        /// <summary>
        /// Updates xml node by reference.
        /// </summary>
        /// <param name="node">Current editing xml node.</param>
        /// <param name="new">New order to be set.</param>
        /// <exception cref="NullReferenceException">Throws if node is null or contains invalid data.</exception>
        public static void EditXmlNode(ref XmlNode node, Order @new)
        {
            if (node == null)
            {
                throw new NullReferenceException("can't edit node");
            }

            if (node.Attributes != null)
            {
                node.Attributes["Id"].Value = @new.Id.ToString();
            }

            var clientData = node.SelectSingleNode("ClientData");
            if (clientData == null)
            {
                throw new NullReferenceException("can't edit ClientData");
            }

            if (clientData.Attributes == null)
            {
                throw new NullReferenceException("can't edit ClientData.Attributes");
            }

            clientData.Attributes["FirstName"].Value = @new.ClientData.FirstName;
            clientData.Attributes["LastName"].Value = @new.ClientData.LastName;
            clientData.Attributes["Email"].Value = @new.ClientData.Email;
            clientData.Attributes["PhoneNumber"].Value = @new.ClientData.PhoneNumber;
            var clientAddress = clientData.SelectSingleNode("Address");
            if (clientAddress == null)
            {
                throw new NullReferenceException("can't edit ClientData.Address");
            }

            if (clientAddress.Attributes == null)
            {
                throw new NullReferenceException("can't edit ClientData.Address.Attributes");
            }

            clientAddress.Attributes["City"].Value = @new.ClientData.AddressModel.City;
            clientAddress.Attributes["Street"].Value = @new.ClientData.AddressModel.Street;
            clientAddress.Attributes["BuildingNumber"].Value = @new.ClientData.AddressModel.BuildingNumber.ToString();
            var shopData = node.SelectSingleNode("ShopData");
            if (shopData == null)
            {
                throw new NullReferenceException("can't edit Order.ShopData");
            }

            if (shopData.Attributes == null)
            {
                throw new NullReferenceException("can't edit Order.ShopData.Attributes");
            }

            shopData.Attributes["Name"].Value = @new.ShopData.Name;
            var shopAddress = shopData.SelectSingleNode("Address");
            if (shopAddress == null)
            {
                throw new NullReferenceException("can't edit ShopData.Address");
            }

            if (shopAddress.Attributes == null)
            {
                throw new NullReferenceException("can't edit ShopData.Address.Attributes");
            }

            shopAddress.Attributes["City"].Value = @new.ShopData.AddressModel.City;
            shopAddress.Attributes["Street"].Value = @new.ShopData.AddressModel.Street;
            shopAddress.Attributes["BuildingNumber"].Value = @new.ShopData.AddressModel.BuildingNumber.ToString();

            var goodsData = node.SelectSingleNode("GoodsData");
            if (goodsData == null)
            {
                throw new NullReferenceException("can't edit Order.GoodsData");
            }

            if (goodsData.Attributes == null)
            {
                throw new NullReferenceException("can't edit Order.GoodsData.Attributes");
            }

            goodsData.Attributes["Code"].Value = @new.GoodsData.Code.ToString();
            goodsData.Attributes["Weight"].Value = @new.GoodsData.Weight.ToString(CultureInfo.InvariantCulture);
        }
    }
}
