using ShopMVC.DAL;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    /// <summary>
    /// Manage all products in the store
    /// </summary>
    public class Store
    {
        private List<Product> Products { get; set; }
        private XmlParser parser { get; set; }
        public Store()
        {
            parser = new XmlParser(Constants.ARTICLES_XML_FILE);
            parser.Parse();
            Products = (List<Product>)parser.GetData();
        }
        /// <summary>
        /// Get all products from the store
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public List<Basket> GetBasketItems(string visitorId, ShopEntities db)
        {
            List<Basket> items = new List<Basket>();
            if (string.IsNullOrEmpty(visitorId))
                return items; // return empty list

            items = db.Baskets.Where(b => b.VisitorId == visitorId).ToList();

            return items;
        }

        /// <summary>
        /// Get single product
        /// </summary>
        /// <param name="productId">product ID</param>
        /// <returns></returns>
        public Product GetProduct(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new NullReferenceException("ProductId is missing and it cannot find a product");

            Product product = Products.Where(p => p.ProductId == productId).FirstOrDefault();
            return product;
        }

        public List<Basket> GetBasketProducts(ShopEntities db, ShopSession session, string visitorId)
        {
            List<Basket> basketItems = new List<Models.Basket>();
            if (string.IsNullOrEmpty(visitorId))
                return basketItems;

            basketItems = new List<Models.Basket>();
            basketItems = db.Baskets.Where(b => b.VisitorId == visitorId).ToList();
            return basketItems;
        }
    }
}