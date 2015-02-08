using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VisitorId { get; set; }

        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}