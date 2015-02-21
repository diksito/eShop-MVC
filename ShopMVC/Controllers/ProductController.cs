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
    public class ProductController : Controller
    {
        private ShopEntities db = new ShopEntities();
        private ShopSession session = new ShopSession();
        private Store store = new Store();
        //
        // GET: /Product/

        public ActionResult Index(string id)
        {
            // Current visitor
            session.CheckSession(HttpContext.Session);

            if (string.IsNullOrEmpty(id))
                return RedirectToAction("NotFound", "Home");

            string visitorId = session.getUser(HttpContext.Session);
            List<Basket> basketItems = db.Baskets.Where(b => b.VisitorId == visitorId).ToList();

            ViewBag.CartCounter = 0;
            if (basketItems != null)
            {
                ViewBag.CartCounter = basketItems.Sum(b => b.Quantity);
            }

            Product product = store.GetProduct(id);

            if(product == null)
                return RedirectToAction("NotFound", "Home");

            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}