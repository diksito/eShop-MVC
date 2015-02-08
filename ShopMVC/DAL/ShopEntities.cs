using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShopMVC.Models;

namespace ShopMVC.DAL
{
    public class ShopEntities : DbContext
    {
        public ShopEntities() : base("DefaultConnection")
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}