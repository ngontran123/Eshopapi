using System;
using System.ComponentModel.DataAnnotations;
namespace Models{
    public class images
    {
        public string url{get;set;}
        public int skuId{get;set;}
        [Key]
        public int id{get;set;}
       public virtual sku _sku{get;set;}
       
    }
}