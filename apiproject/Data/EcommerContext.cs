using Models;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class  EcommerContext : DbContext
    {
        public EcommerContext(DbContextOptions<EcommerContext> options): base(options)
        {
        }
        public DbSet<sku> skus{get;set;}
        public DbSet<order_tbl> ordertable{get;set;}
        public DbSet<order_item> orderitem{get;set;}
        public DbSet<images> images{get;set;}
        public DbSet<customer> customers{get;set;}
        public DbSet<brand> brands{get;set;}
        public DbSet<Products> product{get;set;}
        public DbSet<Address> addresses{get;set;}
        public DbSet<Category> category {get;set;}

    }
}
