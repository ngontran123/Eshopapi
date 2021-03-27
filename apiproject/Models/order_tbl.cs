using System;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class order_tbl
    {   
     
        [Required]
        [Key]
        public int id {get;set;}
        public DateTime createdate {get;set;}
        public DateTime updatedate {get;set;}
        public string paymentmethod {get;set;}
        public decimal  shippingfee {get;set;}
        public string shippingaddress{get;set;}
        public decimal totalprice {get;set;}
        public string status {get;set;}
    }
}