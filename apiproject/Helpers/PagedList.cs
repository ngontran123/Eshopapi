using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Helpers
{
    public class PagedList<T>:Response<T>
    {
        public int pagenumber{get;set;}
        public int pagesize{get;set;}
        public int totalpage{get;set;}
        public Uri firstpage{get;set;}
        public Uri lastpage{get;set;}
        public Uri nextpage{get;set;}
        public Uri prevpage{get;set;}
        public int totalcount{get;set;}
    
    public PagedList(T data,int pagenumber,int pagesize)
    {
        this.pagenumber=pagenumber;
        this.pagesize=pagesize;
        this.Data=data;
    }
    }
}