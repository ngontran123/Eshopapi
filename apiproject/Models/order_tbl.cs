using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Models
{
    public class order_tbl
    {   
     
        [Required]
        [Key]
        public int id {get;set;}
        public DateTime createDate {get;set;}
        public DateTime updateDate {get;set;}
        public string paymentMethod {get;set;}
        public decimal  shippingFee {get;set;}
        public string shippingAddress{get;set;}
        public decimal totalPrice {get;set;}
        public string status {get;set;}
        public IEnumerable<order_item> orderItems{get;set;}
        public int customerId{get;set;}
    }
}