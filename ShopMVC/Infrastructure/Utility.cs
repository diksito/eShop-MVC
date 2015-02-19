using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public class Utility
    {
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