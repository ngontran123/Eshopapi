using System;
namespace DTO{
    public class order_tableDTO
    {
        
        public int id {get;set;}
        public DateTime createDate {get;set;}
        public DateTime updateDate {get;set;}
        public string paymentMethod {get;set;}
        public decimal shippingFee {get;set;}
        public string shippingAddress{get;set;}
        public decimal totalPrice {get;set;}
        public string status{get;set;}
        
    }
}