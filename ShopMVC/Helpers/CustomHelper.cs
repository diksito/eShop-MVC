using ShopMVC.Infrastructure;
using System;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Helpers
{
    public static class CustomHelper
    {
        /// <summary>
        /// Trim text
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Trim(this HtmlHelper helper, string text, int length)
        {
            return Utility.Trim(text, length);
        }
    }
}