using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Infrastructure
{
    public class Paging
    {
        public static int CountAllPages(int allItems)
        {
            int pages = 0;
            if (allItems > Constants.PRODUCTS_PER_PAGE)
                pages = (allItems / Constants.PRODUCTS_PER_PAGE) + 1;

            return pages;
        }

        public static int CountSkippedItems(int page)
        {
            return page * Constants.PRODUCTS_PER_PAGE;
        }
    }
}