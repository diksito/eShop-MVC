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
        //
        // GET: /Product/

        public ActionResult Index(string id)
        {
            // Current visitor
            if (HttpContext.Session[Constants.SESSION_VISITOR] == null)
                HttpContext.Session[Constants.SESSION_VISITOR] = Guid.NewGuid();

            if (string.IsNullOrEmpty(id))
                return RedirectToAction("NotFound", "Home");

            XmlParser xmlParser = new XmlParser();

            Product product = xmlParser.GetProduct(id);

            if(product == null)
                return RedirectToAction("NotFound", "Home");

            return View(product);
        }
    }
}