using ShopMVC.DAL;
using ShopMVC.Infrastructure;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private ShopEntities db = new ShopEntities();

        public ActionResult Index()
        {
            // Current visitor
            if (HttpContext.Session[Constants.SESSION_VISITOR] == null)
                HttpContext.Session[Constants.SESSION_VISITOR] = Guid.NewGuid().ToString();

            string visitorId = (string)HttpContext.Session[Constants.SESSION_VISITOR];
            List<Basket> basketItems = db.Baskets.Where(b => b.VisitorId == visitorId).ToList();

            ViewBag.CartCounter = 0;
            if(basketItems != null)
            {
                ViewBag.CartCounter = basketItems.Sum(b => b.Quantity);
            }

            XmlParser parser = new XmlParser();
            List<Product> products = parser.GetProducts();

            int countProducts = products.Count;

            // count pages
            int pages = 0;
            if(countProducts > Constants.PRODUCTS_PER_PAGE)
                pages = (products.Count / Constants.PRODUCTS_PER_PAGE) + 1;
            ViewBag.Pages = pages;


            Page page = new Page
            {
                Products = products.Take(10).ToList(),
                CountAll = pages
            };


            return View(page);
        }

        // GET: /Home/NotFound
        public ActionResult NotFound()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}