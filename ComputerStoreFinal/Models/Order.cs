using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerStoreFinal.Models
{
    public partial class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string UserName { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Shipping Address")]
        public string ShipAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "ZIP Code")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingTotal { get; set; }
        public decimal SalesTax { get; set; }
        public System.DateTime OrderDate { get; set;}
        public List<OrderPart> OrderPart { get; set; }

    }
}