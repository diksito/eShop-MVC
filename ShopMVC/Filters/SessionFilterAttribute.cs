using ShopMVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace ShopMVC.Filters
{
    public class SessionFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext != null)
            {
                ShopSession session = new ShopSession();
                session.CheckSession(filterContext.HttpContext.Session);
            }
        }
    }
}