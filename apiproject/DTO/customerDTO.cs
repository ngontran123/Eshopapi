using System;
namespace DTO{
    public class customerDTO
    {
           public int id{get;set;}
        public string name{get;set;}
        public string email{get;set;}
        public string phonenumber{get;set;}
        public string gender{get;set;}
        public string password{get;set;}
        public string accesstoken{get;set;}
        public string accesexpire {get;set;}
        public string refreshtoken{get;set;}
        public string refreshexpire{get;set;}
    }
}