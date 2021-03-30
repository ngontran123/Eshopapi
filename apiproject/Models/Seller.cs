using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Models{
    public class Seller{
        [Key]
        [Required]
        public int id{get;set;}
        public String phoneNumer{get;set;}
        [Required]
        public String name{get;set;}
        [Required]
        [EmailAddress]
        public String email{get;set;}
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public String password{get;set;}
        public String secretKey{get;set;}
        public String accessToken{get;set;}
        public String accessExpire{get;set;}
        public String refreshToken{get;set;}
        public String refreshExpire{get;set;}
    }
}