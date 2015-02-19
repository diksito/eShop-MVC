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
        //
        // GET: /Product/

        public ActionResult Index(string id)
        {
            // Current visitor
            if (HttpContext.Session[Constants.SESSION_VISITOR] == null)
                HttpContext.Session[Constants.SESSION_VISITOR] = Guid.NewGuid();

            if (string.IsNullOrEmpty(id))
                return RedirectToAction("NotFound", "Home");

            string visitorId = (string)HttpContext.Session[Constants.SESSION_VISITOR];
            List<Basket> basketItems = db.Baskets.Where(b => b.VisitorId == visitorId).ToList();

            ViewBag.CartCounter = 0;
            if (basketItems != null)
            {
                ViewBag.CartCounter = basketItems.Sum(b => b.Quantity);
            }

            XmlParser xmlParser = new XmlParser();

            Product product = xmlParser.GetProduct(id);

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