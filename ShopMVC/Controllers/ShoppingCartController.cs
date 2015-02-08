using ShopMVC.DAL;
using ShopMVC.Infrastructure;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShopMVC.Controllers
{
    public class ShoppingCartController : ApiController
    {
        ShopEntities db = new ShopEntities();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(string productId, int qty)
        {
            Basket basket = new Basket
            {
                BasketId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                VisitorId = (string)HttpContext.Current.Session[Constants.SESSION_VISITOR]
            };
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}