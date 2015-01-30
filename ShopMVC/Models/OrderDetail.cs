using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
    }
}