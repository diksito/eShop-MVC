using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Cart/CheckOut

        public ActionResult CheckOut()
        {
            return View();
        }

        //
        // GET: /Cart/ThankYou

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}
