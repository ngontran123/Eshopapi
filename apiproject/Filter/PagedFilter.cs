using System;
using Helpers;
using System.Collections.Generic;
namespace Filter
{
    public class PagedFilter
    {
        public int pagenumber{get;set;}
        public int pagesize{get;set;}
        public PagedFilter()
        {
            this.pagenumber=1;
            this.pagesize=1;
        }
        public PagedFilter(int pagenumber,int pagesize)
        {
            this.pagenumber= pagenumber< 1 ? 1:pagenumber;
            this.pagesize=pagesize>10?10:pagesize;
        }

    }
}