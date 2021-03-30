using System;
using System.ComponentModel.DataAnnotations;
namespace Models{
    public class customer
    {    [Required]
    [Key]
        public int id{get;set;}
        public string name{get;set;}
        [EmailAddress]
        public string email{get;set;}
        public string phoneNumber{get;set;}
        public string gender{get;set;}
         [StringLength(10, MinimumLength = 5)]
        public string password{get;set;}
        public string accessToken{get;set;}
        public string accesExpire {get;set;}
        public string refreshToken{get;set;}
        public string refreshExpire{get;set;}

    }
}
