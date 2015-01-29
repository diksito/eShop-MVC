using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public class XmlReader
    {
        public string XmlFilePath { get; set; }
        public XmlReader(string filePath)
        {
            this.XmlFilePath = filePath;
        }
    }
}