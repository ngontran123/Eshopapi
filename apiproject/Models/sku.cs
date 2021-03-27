using System;
using System.ComponentModel.DataAnnotations;
namespace Models{
    public class sku{
   [Required]
   [Key]
    public int id {get;set;}
       [StringLength(60, MinimumLength = 3)]
        [Display(Name="Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string seller_sku {get;set;}
        [Required]
        public int productid{get;set;}
        public int available {get;set;}
        public int quantity {get;set;}
        public string color{get;set;}
        public int size{get;set;}
        public int heigth{get;set;}
        public int width{get;set;}
        public int length{get;set;}
        public int weight{get;set;}
        [RegularExpression(@"\D+")]
        public decimal price{get;set;}
        public virtual Products product{get;set;}
    }
}