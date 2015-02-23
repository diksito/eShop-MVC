﻿using ShopMVC.DAL;
using ShopMVC.Infrastructure;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class CartController : Controller
    {
        private ShopEntities db = new ShopEntities();
        private ShopSession session = new ShopSession();
        private Store store = new Store();

        //
        // GET: /Bassket/
        public ActionResult Basket()
        {
            string visitorId = session.getUser(HttpContext.Session);
            List<Basket> basketItems = store.GetBasketProducts(db, session, visitorId);
            ViewBag.CartCounter = basketItems.Sum(b => b.Quantity);

            List<Product> myBasketProducts = new List<Product>();

            foreach (var item in basketItems)
            {
                Product product = store.GetProduct(item.ProductId);
                product.Quantity = basketItems.Where(p => p.ProductId == item.ProductId).Sum(b => b.Quantity);
                myBasketProducts.Add(product);
            }

            BasketSession basket = new BasketSession(myBasketProducts);

            return View(basket);
        }

        //
        // GET: /Cart/CheckOut

        public ActionResult CheckOut()
        {
            Order order = new Order
            {
                CreatedDate = DateTime.UtcNow
            };
            return View(order);
        }

        //
        // POST: /Cart/CheckOut

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(Order order)
        {
            if (ModelState.IsValid)
            {
                string visitorId = session.getUser(HttpContext.Session);
                List<Basket> basketItems = store.GetBasketProducts(db, session, visitorId);

                try
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    ModelState.AddModelError("", "Cannot save your order please, try again.");
                    return View(order);
                }

                try
                {
                    foreach (var item in basketItems)
                    {
                        Product product = store.GetProduct(item.ProductId);

                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = order.OrderId,
                            Price = product.Price,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            CreatedDate = DateTime.UtcNow
                        };
                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();

                        // Remove from basket
                        db.Baskets.Remove(item);
                        db.SaveChanges();
                    }
                }
                catch(Exception)
                {
                    ModelState.AddModelError("", "Cannot save your order details please, try again.");
                    return View(order);
                }
                return RedirectToAction("ThankYou", "Cart");
            }
            else
            {
                return View(order);
            }
        }

        //
        // GET: /Cart/ThankYou

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Add(string productId, int qty)
        {
            if(string.IsNullOrEmpty(productId))
                return Json( new { status = false });

            if (qty < 1)
                return Json(new { status = false });

            string visitorId = session.getUser(HttpContext.Session);

            Basket existingItem = db.Baskets.Where(b => b.VisitorId == visitorId && b.ProductId == productId).FirstOrDefault();
            if(existingItem != null)
            {
                existingItem.Quantity += qty;
                try
                {
                    db.Entry(existingItem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    return Json(new { status = false });
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
                    return Json(new { status = false });
                }
            }

            List<Basket> basketItems = db.Baskets.Where(b => b.VisitorId == visitorId).ToList();
            int countItems = qty;
            if (basketItems != null)
            {
                countItems = basketItems.Sum(a => a.Quantity);
            }

            return Json(new { status = true, qty = countItems });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
