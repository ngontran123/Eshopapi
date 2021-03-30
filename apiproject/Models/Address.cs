using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models{
    public class Address
    {  [Required]
       [Key]
        public int id{get;set;}
        [Required]
        public int cusId{get;set;}
        public String street{get;set;}
        [EmailAddress]
        public String address1{get;set;}
        [EmailAddress]
        public String address2{get;set;}
        [EmailAddress]
        public String address3{get;set;}
        public virtual customer cus{get;set;}
    }
}