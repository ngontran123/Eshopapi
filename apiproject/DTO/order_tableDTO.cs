using System;
namespace DTO{
    public class order_tableDTO
    {
        
        public int id {get;set;}
        public DateTime createdate {get;set;}
        public DateTime updatedate {get;set;}
        public string paymentmethod {get;set;}
        public decimal shippingfee {get;set;}
        public string shippingaddress{get;set;}
        public decimal totalprice {get;set;}
        public string status{get;set;}
        
    }
}