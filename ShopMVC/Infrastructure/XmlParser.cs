using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ShopMVC.Infrastructure
{
    public class XmlParser
    {
        private string xmlFilePath = "~/App_Data/Articles.xml";
        public XmlParser()
        {
            if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(xmlFilePath)))
                throw new Exception("XML file with articles is missing");
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            #region Parsing XML
            XmlDocument xmlDoc= new XmlDocument(); // Create an XML document object
            xmlDoc.Load(HttpContext.Current.Server.MapPath(xmlFilePath)); // Load the XML document from the specified file

            // Get elements
            XmlNodeList idNode = xmlDoc.GetElementsByTagName("id");
            XmlNodeList titleNode = xmlDoc.GetElementsByTagName("title");
            XmlNodeList descriptionNode = xmlDoc.GetElementsByTagName("description");
            XmlNodeList priceNode = xmlDoc.GetElementsByTagName("price");
            
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
                catch(Exception) { }
            }
            #endregion

            return products;
        }
    }
}