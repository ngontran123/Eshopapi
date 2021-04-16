using System;
using System.Collections.Generic;
namespace DTO
{
    
public class SkuDTO
{      public int id {get;set;}
        public string seller_sku {get;set;}
    
        public int available {get;set;}
        public int quantity {get;set;}
        public string color{get;set;}
        public int size{get;set;}
        public int heigth{get;set;}
        public int width{get;set;}
        public int length{get;set;}
        public int weight{get;set;}
        public decimal price{get;set;}
        public IEnumerable<imageDTO> image1{get;set;}
        public int productId{get;set;}
}
}