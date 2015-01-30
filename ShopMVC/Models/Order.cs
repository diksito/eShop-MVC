using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Title field is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "First name field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address field is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "House number field is required")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Zip code field is required")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        public virtual List<OrderDetail> OrderDetils { get; set; }
    }
}