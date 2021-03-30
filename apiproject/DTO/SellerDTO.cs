using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Models{
    public class SellerDTO{
        public int id{get;set;}
        public String phoneNumer{get;set;}
        public String name{get;set;}

        public String email{get;set;}
        public String password{get;set;}
        public String secretKey{get;set;}
        public String accessToken{get;set;}
        public String accessExpire{get;set;}
        public String refreshToken{get;set;}
        public String refreshExpire{get;set;}
    }
}