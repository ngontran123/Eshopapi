using System;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class order_item
    {[Required]
    [Key]
           public int id{get;set;}
       [Required]
        public int orderid{get;set;}
        [Required]
        public int skuid{get;set;}
        [StringLength(60,MinimumLength=10)]
        public string name{get;set;}
        public string variation{get;set;}
        public decimal price{get;set;}
        public int quantity {get;set;}
        public virtual order_tbl table{get;set;}
        public virtual sku _sku{get;set;}
    }
}