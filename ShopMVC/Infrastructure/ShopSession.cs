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
        public string getUser(HttpSessionStateBase session)
        {
            return (string)session[Constants.SESSION_VISITOR];
        }
        /// <summary>
        /// Check if user's session is existing if not create a new one
        /// </summary>
        public void CheckSession(HttpSessionStateBase session)
        {
            initSession(session);
        }

        private void initSession(HttpSessionStateBase session)
        {
            if (session[Constants.SESSION_VISITOR] == null)
                session[Constants.SESSION_VISITOR] = Guid.NewGuid().ToString();
        }
    }
}