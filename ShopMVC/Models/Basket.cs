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
    }
}