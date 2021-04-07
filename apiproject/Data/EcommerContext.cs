using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.AspNetCore.Identity;
namespace Data
{
    public class  EcommerContext : IdentityDbContext<Applicationuser>
    {
        public EcommerContext(DbContextOptions<EcommerContext> options): base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
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
        public DbSet<Seller> seller{get;set;}
        public DbSet<Selleraddress> selleraddresses{get;set;}
        public DbSet<Cart> cart{get;set;}
        public DbSet<Refreshtoken> refreshtokens{get;set;}
    }
}
