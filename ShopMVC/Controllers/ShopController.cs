using ShopMVC.DAL;
using ShopMVC.Infrastructure;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShopMVC.Controllers
{
    public class ShopController : ApiController
    {
        private ShopEntities db = new ShopEntities();
        private ShopSession session = new ShopSession();
        private Store store = new Store();

        // GET api/<controller>
        public List<Product> GetProducts(int page)
        {
            List<Product> products = store.GetAllProducts();
            int skipProducts = page * Constants.PRODUCTS_PER_PAGE;
            int tillProduct = skipProducts + Constants.PRODUCTS_PER_PAGE;

            List<Product> productPerPage = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if ((skipProducts - 1) < i && tillProduct > i)
                {
                    products[i].Description = Utility.Trim(products[i].Description, 30); // trim description
                    productPerPage.Add(products[i]);
                }
            }

            return productPerPage;
        }

        // GET api/<controller>/Add/5
        public ProductSummary Post([FromBody]ProductAdd product)
        {
            int qty = product.quantity;
            string productId = product.productId;
            ProductSummary summary = new ProductSummary
            {
                Status = false
            };
            if (string.IsNullOrEmpty(productId))
                return summary;

            if (qty < 1)
                return summary;

            var context = HttpContext.Current;
            HttpContextBase abstractContext = new System.Web.HttpContextWrapper(context);

            string visitorId = session.getUser(abstractContext.Session);

            Basket existingItem = db.Baskets.Where(b => b.VisitorId == visitorId && b.ProductId == productId).FirstOrDefault();
            if (existingItem != null)
            {
                existingItem.Quantity += qty;
                try
                {
                    db.Entry(existingItem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return summary;
                }
            }
            else
            {
                Basket basket = new Basket
                {
                    BasketId = Guid.NewGuid(),
                    VisitorId = visitorId,
                    Quantity = qty,
                    ProductId = productId,
                    CreatedDate = DateTime.UtcNow
                };
                try
                {
                    db.Baskets.Add(basket);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return summary;
                }
            }

            List<Basket> basketItems = store.GetBasketItems(visitorId, db);
            int countItems = basketItems.Sum(a => a.Quantity);

            summary.Status = true;
            summary.Quantity = countItems;

            return summary;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}