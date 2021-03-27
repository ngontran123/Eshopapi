using System;
using System.Linq;
using Models;
using System.Collections.Generic;
using Data;
namespace Data{
    public class Seeds
    {
        public static void Seed(EcommerContext context)
        {
            context.Database.EnsureCreated();
        
            if(!context.brands.Any())
            {
              List<brand> b1=new List<brand>()
              {
                   new brand{
                       id=1,
                       name="number1"
                   },
                   new brand{
                       id=2,
                       name="number2"
                   },
                   new brand{
                       id=3,
                       name="number3"
                   }
              };
              context.brands.AddRange(b1);
               context.SaveChanges();
            }
            if(!context.product.Any())
            {
                List<Products> p1=new List<Products>()
                {  new Products
                {
                    id=1,
                    categoryid=1,
                    brandid=1,
                    productname="New phone",
                    description="newest product",
                    status="yes",
                    Category=Categories["hello long tran"]
            
                },
                 new Products
                {
                    id=2,
                    categoryid=1,
                    brandid=2,
                    productname="New phone1",
                    description="newest product1",
                    status="yes",
                    Category=Categories["hello long tran"]
                
                }
                };
                context.product.AddRange(p1);
                context.SaveChanges();
            }
                 if(!context.skus.Any())
            {
                context.skus.AddRange(new List<sku>()
                {
                  new sku{
                      
                      seller_sku="Nguyen van A",
                      available=1,
                      quantity=100,
                      color="Đỏ",
                       size=15,
                       heigth=20,
                       width=20*15,
                       length=200,
                       weight=30,
                       price=35M,
                       productid=2
                       

                  },
                  new sku{
                      
                      seller_sku="Nguyen van B",
                      available=1,
                      quantity=100,
                      color="Xanh",
                       size=15,
                       heigth=20,
                       width=20*15,
                       length=200,
                       weight=30,
                       price=20M,
                       productid=1
                    

                  }
                }
                
                );
                context.SaveChanges();
                
            }
        }
        public static Products product1;
               private static Dictionary<string,Category> categories;
       public static brand brand1;
       public static Dictionary<string,Category> Categories
       {
           get{
               if(categories==null)
               {
                   var genrelist=new Category[]
                   {
                       new Category{
                           id=1,
                           name="hello long tran"
                       }
                       ,new Category{
                           id=2,
                           name="fuck off"
                       }
                   };
                   categories=new Dictionary<string, Category>();
                   foreach(var genre in genrelist)
                   {
                       categories.Add(genre.name,genre);
                   }
                
               }
               return categories;
           
       }

           
                
            }
        }
    }

    