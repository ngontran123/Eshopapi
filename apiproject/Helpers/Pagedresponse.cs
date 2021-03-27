using System;
using System.Collections.Generic;
using Filter;
using Baseurl;
namespace Helpers
{
    public class Pagedresponse
    {
        public static PagedList<IEnumerable<T>> createpagedresponse<T>(IEnumerable<T> data,PagedFilter filter,int totalcount,IrulService uriservice,string route)
        {
            var res=new PagedList<IEnumerable<T>>(data,filter.pagenumber,filter.pagesize);
            var totalpage=(double)totalcount/(double)filter.pagesize;
            int totalpage1=Convert.ToInt32(Math.Ceiling(totalpage));
            res.nextpage=filter.pagenumber>=1&&filter.pagenumber<totalpage ? uriservice.getpageurl(new PagedFilter(filter.pagenumber+1,filter.pagesize),route):null;
            res.prevpage=filter.pagenumber-1>=1&&filter.pagenumber<=totalpage ? uriservice.getpageurl(new PagedFilter(filter.pagenumber-1,filter.pagesize),route):null;
            res.firstpage=uriservice.getpageurl(new PagedFilter(1,filter.pagesize),route);
            res.lastpage=uriservice.getpageurl(new PagedFilter(totalpage1,filter.pagesize),route);
            res.totalpage=totalpage1;
            return res;
        } 
    }
}