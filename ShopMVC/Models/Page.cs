using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class Page
    {
        public int Current { get; set; }
        public int CountAll { get; set; }

        public List<Product> Products { get; set; }
    }
}