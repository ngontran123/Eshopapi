using System;
using Helpers;
using System.Collections.Generic;
namespace Filter
{
    public class PagedFilter
    {
        public int pageIndex{get;set;}
        public int pageSize{get;set;}
        // public PagedFilter()
        // {
        //     this.pageIndex=1;
        //     this.pagesize=1;
        // }
        public PagedFilter(int pageIndex, int pagesize)
        {
            this.pageIndex= pageIndex< 1 ? 1:pageIndex;
            this.pageSize=pagesize>10?10:pagesize;
        }

        public PagedFilter()
        {
            this.pageIndex = 1;
            this.pageSize= 10;
        }

    }
}