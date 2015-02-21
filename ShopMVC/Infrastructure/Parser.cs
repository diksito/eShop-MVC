using ShopMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public abstract class Parser : IParser
    {
        public string FileName { get; set; }
        private Object Data;

        public Parser()
        {

        }
        public Parser(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
                throw new Exception("File does not exist");

            this.FileName = fileName;
        }
        public virtual Object GetData()
        {
            if (Data == null)
                throw new NullReferenceException("Cannot load parsed data. Please be sure that you already parsed the data!");
            
            return Data;
        }

        public virtual void Parse()
        {
        }
    }
}