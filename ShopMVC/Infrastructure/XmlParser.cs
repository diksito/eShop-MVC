using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ShopMVC.Infrastructure
{
    public class XmlParser : Parser
    {
        private string xmlFilePath = "~/App_Data/Articles.xml";

        private List<Product> products { get; set; }

        //public override List<Product> Data { get; set; }
        public XmlParser()
        {

        }

        public XmlParser(string fileName)
        {
            if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(fileName)))
                throw new Exception("XML file with articles is missing");
        }
        public override Object GetData()
        {
            return products;
        }

        public override void Parse()
        {
            products = new List<Product>();
            #region Parsing XML
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.Load(HttpContext.Current.Server.MapPath(xmlFilePath)); // Load the XML document from the specified file

            // Get elements
            XmlNodeList idNode = xmlDoc.GetElementsByTagName(XMLField.ID);
            XmlNodeList titleNode = xmlDoc.GetElementsByTagName(XMLField.TITLE);
            XmlNodeList descriptionNode = xmlDoc.GetElementsByTagName(XMLField.DESCRIPTION);
            XmlNodeList priceNode = xmlDoc.GetElementsByTagName(XMLField.PRICE);

            for (int i = 0; i < idNode.Count; i++)
            {
                try
                {
                    decimal currPrice = 0;
                    Decimal.TryParse(priceNode[i].InnerText, out currPrice);

                    products.Add(new Product
                    {
                        ProductId = idNode[i].InnerText,
                        Title = titleNode[i].InnerText,
                        Description = descriptionNode[i].InnerText,
                        Price = currPrice
                    });
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            #endregion
        }

        /// <summary>
        /// XML Node names
        /// </summary>
        class XMLField
        {
            public const string ID = "id";
            public const string TITLE = "title";
            public const string DESCRIPTION = "description";
            public const string PRICE = "price";
        }
    }
}