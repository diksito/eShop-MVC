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
    public class ProductController : Controller
    {
        private ShopEntities db = new ShopEntities();
        private ShopSession session = new ShopSession();
        private Store store = new Store();
        //
        // GET: /Product/

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("NotFound", "Home");

            string visitorId = session.getUser(HttpContext.Session);
            
            List<Basket> basketItems = store.GetBasketItems(visitorId, db);
            ViewBag.CartCounter = basketItems.Sum(b => b.Quantity);

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