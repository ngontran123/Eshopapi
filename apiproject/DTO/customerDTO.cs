using System;
namespace DTO{
    public class customerDTO
    {
           public int id{get;set;}
        public string name{get;set;}
        public string email{get;set;}
        public string phoneNumber{get;set;}
        public string gender{get;set;}
        public string password{get;set;}
        public string accessToken{get;set;}
        public string accesExpire {get;set;}
        public string refreshToken{get;set;}
        public string refreshExpire{get;set;}
    }
}