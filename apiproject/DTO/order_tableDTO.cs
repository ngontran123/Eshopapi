using System;
using System.Collections.Generic;
namespace DTO{
    public class OrderTableDTO
    {
        
        public int id {get;set;}
        public DateTime createDate {get;set;}
        public DateTime updateDate {get;set;}
        public string paymentMethod {get;set;}
        public decimal shippingFee {get;set;}
        public string shippingAddress{get;set;}
        public decimal totalPrice {get;set;}
        public string status{get;set;}
        public int customerId{get;set;}
       public IEnumerable<order_itemDTO> orderItems{get;set;}
       public customerDTO customer{get;set;}
    }
}