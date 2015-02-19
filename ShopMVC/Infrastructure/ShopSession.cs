using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public class ShopSession
    {
        public ShopSession()
        {
        }
        /// <summary>
        /// Get current user's session id
        /// </summary>
        /// <returns></returns>
        public string getUser(HttpContextBase http)
        {
            initSession(http);
            return (string)http.Session[Constants.SESSION_VISITOR];
        }
        /// <summary>
        /// Check if user's session is existing if not create a new one
        /// </summary>
        public void CheckSession(HttpContextBase http)
        {
            initSession(http);
        }

        private void initSession(HttpContextBase http)
        {
            if (http.Session[Constants.SESSION_VISITOR] == null)
                http.Session[Constants.SESSION_VISITOR] = Guid.NewGuid().ToString();
        }
    }
}