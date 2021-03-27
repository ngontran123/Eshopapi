using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Models{
    public class Products
    {
        [Required]
        [Key]
        public int id{get;set;}
        public int categoryid{get;set;}
        public int brandid{get;set;}
        public String productname{get;set;}
        public String description{get;set;}
        public String status{get;set;}
        public virtual brand Brand{get;set;}
        public virtual Category Category{get;set;}

    }
}