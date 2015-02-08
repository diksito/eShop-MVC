using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class BasketSession
    {
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithoutVat { get; set; }

        public BasketSession(List<Product> products)
        {
            this.Products = products;
            decimal total = 0;
            foreach (var item in products)
            {
                total += item.Quantity * item.Price;
            }
            TotalPrice = total;
            TotalPriceWithoutVat = TotalPrice - (Decimal.Multiply(TotalPrice, 0.2m)); 
        }
    }
}