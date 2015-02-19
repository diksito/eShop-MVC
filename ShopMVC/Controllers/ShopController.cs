using ShopMVC.DAL;
using ShopMVC.Infrastructure;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopMVC.Controllers
{
    public class ShopController : ApiController
    {
        private ShopEntities db = new ShopEntities();

        // GET api/<controller>
        public List<Product> GetProducts(int page)
        {
            XmlParser parser = new XmlParser();
            List<Product> products = parser.GetProducts();
            int skipProducts = page * Constants.PRODUCTS_PER_PAGE;
            int tillProduct = skipProducts + Constants.PRODUCTS_PER_PAGE;

            List<Product> productPerPage = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if ((skipProducts - 1) < i && tillProduct > i)
                {
                    // trim description
                    if (products[i].Description.Length > 30)
                        products[i].Description = products[i].Description.Substring(0, 30) + "...";

                    productPerPage.Add(products[i]);
                }
            }

            return productPerPage;
        }

        // GET api/<controller>/AddToBasket/5
        public void AddToBasket(string productId, int qty)
        {
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}