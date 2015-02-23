﻿using ShopMVC.DAL;
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
        private ShopSession session = new ShopSession();
        private Store store = new Store();

        public ActionResult Index()
        {
            string visitorId = session.getUser(HttpContext.Session);

            List<Basket> basketItems = store.GetBasketItems(visitorId, db);
            ViewBag.CartCounter = basketItems.Sum(b => b.Quantity);

            List<Product> products = store.GetAllProducts();
            int countProducts = products.Count;

            // count pages
            int pages = 0;
            if(countProducts > Constants.PRODUCTS_PER_PAGE)
                pages = (products.Count / Constants.PRODUCTS_PER_PAGE) + 1;

            Page page = new Page
            {
                Products = products.Take(Constants.PRODUCTS_PER_PAGE).ToList(),
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