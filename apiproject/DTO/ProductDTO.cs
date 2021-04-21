using System;
using System.Collections.Generic;
namespace DTO{
    public class ProductDTO
    {
         public int id{get;set;}
        public int categoryId{get;set;}
        public int brandId{get;set;}
        public String productName{get;set;}
        public String description{get;set;}
        public String status{get;set;}
         public IEnumerable<SkuDTO> skus{get;set;}
    }
}