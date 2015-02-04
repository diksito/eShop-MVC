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
        public ActionResult Index()
        {
            ViewBag.CartCounter = 0;
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
                Products = products,
                Current = 1,
                CountAll = pages
            };


            return View(page);
        }
    }
}