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
        /*
         * XmlDocument xmlDoc= new XmlDocument(); // Create an XML document object
xmlDoc.Load("yourXMLFile.xml"); // Load the XML document from the specified file

// Get elements
XmlNodeList girlAddress = xmlDoc.GetElementsByTagName("gAddress");
XmlNodeList girlAge = xmlDoc.GetElementsByTagName("gAge"); 
XmlNodeList girlCellPhoneNumber = xmlDoc.GetElementsByTagName("gPhone");

// Display the results
Console.WriteLine("Address: " + girlAddress[0].InnerText);
Console.WriteLine("Age: " + girlAge[0].InnerText);
Console.WriteLine("Phone Number: " + girlCellPhoneNumber[0].InnerText);
         */
    }
}