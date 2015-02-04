using System;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Helpers
{
    public static class UrlHelper
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
            if(text.Length < length)
            {
                return text;
            }
            else
            {
                return text.Substring(0, length) + "...";
            }
        }
    }
}