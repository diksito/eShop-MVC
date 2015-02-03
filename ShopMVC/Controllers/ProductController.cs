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
            if (string.IsNullOrEmpty(id))
                return HttpNotFound("Home");

            return View();
        }
    }
}