using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public class Utility
    {
        /// <summary>
        /// Trim text to specific length
        /// </summary>
        /// <param name="text">text that will be trimmed</param>
        /// <param name="length">length of the text that will be returned</param>
        /// <returns>trimmed text</returns>
        public static string Trim(string text, int length)
        {
            if (text.Length < length)
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