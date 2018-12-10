using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.Xml.Serialization;

using Wpf_Service.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wpf_Service.Orders
{
    public interface IDataErrorInfo
    {
        string Error { get; }
        string this[string columnName] { get; }
    }
    /// <summary>
	/// Represents an order.
	/// </summary>
    public class Order : IDataErrorInfo
    {
        /// <summary>
        /// Holds an id of the order.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Contains client personal information.
        /// </summary>
        public string ClientKey { get; set; }
        [ForeignKey("ClientKey")]
        public ClientModel ClientData { get; set; }

        /// <summary>
        /// Represents shop data.
        /// </summary>
        public string StoreId { get; set; }
        [ForeignKey("StoreId")]
        public StoreModel ShopData { get; set; }

        /// <summary>
        /// Holds an information about ordered goods.
        /// </summary>
        public string ProdId { get; set; }
        [ForeignKey("ProdId")]
        public ProductModel GoodsData { get; set; }


        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="id">An id of the order.</param>
        /// <param name="clientData">Client data object.</param>
        /// <param name="shopData">Shop data object.</param>
        /// <param name="goodsData">Goods data object.</param>
        public Order(long id, ClientModel clientData, StoreModel shopData, ProductModel goodsData)
        {
            Id = id.ToString();
            ClientData = clientData;
            ShopData = shopData;
            GoodsData = goodsData;
            ProdId = GoodsData.Code;
            StoreId = ShopData.Name;
            ClientKey = ClientData.getKey();
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
        /// Updates xml node by reference.
        /// </summary>
        /// <param name="node">Current editing xml node.</param>
        /// <param name="new">New order to be set.</param>
        /// <exception cref="NullReferenceException">Throws if node is null or contains invalid data.</exception>
    
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Email":
                        if (true)
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "PhoneNumber":
                        if (true)
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;

                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
