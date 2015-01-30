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
        }
    }
}