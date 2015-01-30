using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public class XmlParser
    {
        public string XmlFilePath { get; set; }
        public XmlParser(string filePath)
        {
            this.XmlFilePath = filePath;

            // TODO: check if file exists
            // if so throws an exception
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            // TODO: Start parsing here...

            return products;
        }
    }
}