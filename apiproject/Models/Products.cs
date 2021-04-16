using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
namespace Models{
    public class Products
    {
        [Required]
        [Key]
        public int id{get;set;}
        public int categoryId{get;set;}
        public int brandId{get;set;}
        public String productName{get;set;}
        public String description{get;set;}
        public String status{get;set;}
        public virtual brand Brand{get;set;}
         public IEnumerable<sku> skus1{get;set;}
        public virtual Category Category{get;set;}
    }
}