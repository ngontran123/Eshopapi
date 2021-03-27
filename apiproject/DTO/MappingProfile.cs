using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
namespace DTO{
    public static class MappingProfile
    {
       public static SkuDTO toskuDTO(this sku sku1)
       {return new SkuDTO()
       {
         id=sku1.id,
        seller_sku=sku1.seller_sku,
         available=sku1.available,
         quantity=sku1.quantity,
        color=sku1.color,
         size=sku1.size,
         heigth=sku1.heigth,
       width=sku1.width,
        length=sku1.length,
         weight=sku1.weight,
         price=sku1.price
       };
       }
       public static sku tosku(this SkuDTO sku2)
       {
           return new sku()
           {
                
        seller_sku=sku2.seller_sku,
         available=sku2.available,
         quantity=sku2.quantity,
        color=sku2.color,
         size=sku2.size,
         heigth=sku2.heigth,
       width=sku2.width,
        length=sku2.length,
         weight=sku2.weight,
         price=sku2.price
           };
       }
       public static void Mapto(this sku sku1,SkuDTO sku2)
       {
        sku1.id=sku2.id;
        sku1.seller_sku=sku2.seller_sku;
         sku1.available=sku2.available;
         sku1.quantity=sku2.quantity;
        sku1.color=sku2.color;
         sku1.size=sku2.size;
        sku1.heigth=sku2.heigth;
       sku1.width=sku2.width;
        sku1.length=sku2.length;
         sku1.weight=sku2.weight;
         sku1.price=sku2.price;
       }
           public static order_itemDTO toorder_itemDTO(this order_item ori)
       {
           return new order_itemDTO()
           {
                 id=ori.id,
         orderid=ori.orderid,
         skuid=ori.skuid,
         name=ori.name,
        variation=ori.variation,
         price=ori.price,
         quantity=ori.quantity
           };
       }
       public static order_item toorder_item(this order_itemDTO ori1)
       {
           return new order_item()
           {
                 id=ori1.id,
         orderid=ori1.orderid,
         skuid=ori1.skuid,
         name=ori1.name,
        variation=ori1.variation,
         price=ori1.price,
         quantity=ori1.quantity
           };
       }
       public static void Mapto1(this order_item ori,order_itemDTO ori1)
       {
           
                 ori.id=ori1.id;
         ori.orderid=ori1.orderid;
         ori.skuid=ori1.skuid;
         ori.name=ori1.name;
        ori.variation=ori1.variation;
         ori.price=ori1.price;
         ori.quantity=ori1.quantity;
       }
       public static order_tableDTO toorder_tblDTO(this order_tbl ord)
       {
           return new order_tableDTO()
           {
                
        createdate=ord.createdate,
        updatedate=ord.updatedate,
       paymentmethod=ord.paymentmethod,
         shippingfee=ord.shippingfee,
         shippingaddress=ord.shippingaddress,
          totalprice=ord.totalprice,
       status=ord.status
           };
       }
       public static order_tbl toorder_tbl(this order_tableDTO ord1)
       {  return new order_tbl()
       {
                
        createdate=ord1.createdate,
        updatedate=ord1.updatedate,
       paymentmethod=ord1.paymentmethod,
         shippingfee=ord1.shippingfee,
         shippingaddress=ord1.shippingaddress,
          totalprice=ord1.totalprice,
          status=ord1.status
       };
    }
    public static void Mapto2(this order_tbl ord, order_tableDTO ord1)
    {
             ord.id=ord1.id;
        ord.createdate=ord1.createdate;
        ord.updatedate=ord1.updatedate;
       ord.paymentmethod=ord1.paymentmethod;
         ord.shippingfee=ord1.shippingfee;
         ord.shippingaddress=ord1.shippingaddress;
          ord.totalprice=ord1.totalprice;
       ord.status=ord1.status;
    }
   public static imageDTO toimageDto(this images img)
   {
       return new imageDTO()
       {
            url=img.url,
         skuid=img.skuid,
    
       };
   }
   public static images toimage(this imageDTO img1)
   {
       return new images()
       {
            url=img1.url,
         skuid=img1.skuid
    
       };
   }
    public static void Mapto3(this images img,imageDTO img1)
    {
        img.url=img1.url;
         img.skuid=img1.skuid;
    }
    public static customerDTO tocustomerDTO(this customer c)
    {
      return new customerDTO()
      { 
              id=c.id,
        name=c.name,
         email=c.email,
         phonenumber=c.phonenumber,
         gender=c.gender,
         password=c.password,
        accesstoken=c.accesstoken,
         accesexpire=c.accesexpire,
       refreshtoken=c.refreshtoken,
         refreshexpire=c.refreshexpire
      };
    }
    public static customer tocustomer(this customerDTO c1)
    {   return new customer()
    {
            id=c1.id,
        name=c1.name,
         email=c1.email,
         phonenumber=c1.phonenumber,
         gender=c1.gender,
         password=c1.password,
        accesstoken=c1.accesstoken,
         accesexpire=c1.accesexpire,
       refreshtoken=c1.refreshtoken,
         refreshexpire=c1.refreshexpire
    };  
    }
    public static void Mapto4(this customer c,customerDTO c1)
    {
            c.id=c1.id;
        c.name=c1.name;
         c.email=c1.email;
         c.phonenumber=c1.phonenumber;
         c.gender=c1.gender;
         c.password=c1.password;
        c.accesstoken=c1.accesstoken;
         c.accesexpire=c1.accesexpire;
       c.refreshtoken=c1.refreshtoken;
         c.refreshexpire=c1.refreshexpire;
    }
  public static brand toBrand(this brandDTO b)
  { return new brand()
  {
    id=b.id,
    name=b.name
  };

  }
  public static brandDTO toBrandDTO(this brand b1)
{
  return new brandDTO()
  {
    id=b1.id,
    name=b1.name
  };
}
public static void Mapto5(this brand b,brandDTO b1)
{
  b.id=b1.id;
  b.name=b1.name;
}
public static ProductDTO toproductdto(this Products pr1 )
{
    return new ProductDTO(){
            id=pr1.id,
        categoryid=pr1.categoryid,
        brandid=pr1.brandid,
         productname=pr1.productname,
      description=pr1.description,
         status=pr1.status
    };
}
public static Products toproduct(this ProductDTO pr2)
{
  return new Products()
  {
            id=pr2.id,
        categoryid=pr2.categoryid,
        brandid=pr2.brandid,
         productname=pr2.productname,
      description=pr2.description,
         status=pr2.status
  };
}
public static void Mapto6(this Products pr1,ProductDTO pr2)
{
          pr1.id=pr2.id;
        pr1.categoryid=pr2.categoryid;
        pr1.brandid=pr2.brandid;
         pr1.productname=pr2.productname;
      pr1.description=pr2.description;
         pr1.status=pr2.status;
}
public static AddressDTO toaddressdto(this Address ad)
{
  return new AddressDTO()
  {
         id=ad.id,
         cusid=ad.cusid,
         street=ad.street,
        address1=ad.address1,
        address2=ad.address2,
         address3=ad.address3
  };
}
  public static Address toaddress(this AddressDTO ad1)
  {
    return new Address()
    {
       id=ad1.id,
         cusid=ad1.cusid,
         street=ad1.street,
        address1=ad1.address1,
        address2=ad1.address2,
         address3=ad1.address3
    };
  }
  public static void Mapto7(this Address ad,AddressDTO ad1)
  {
     ad.id=ad1.id;
         ad.cusid=ad1.cusid;
         ad.street=ad1.street;
        ad.address1=ad1.address1;
        ad.address2=ad1.address2;
         ad.address3=ad1.address3;
  }
  public static CategoryDTO tocategoryDTO(this Category c)
  {
    return new CategoryDTO()
    {
      id=c.id,
      name=c.name
    };
  }
  public static Category tocategory(this CategoryDTO c1)
  {
    return new Category()
    {
      id=c1.id,
      name=c1.name
    };
  }
  public static void Mapto8(this Category c,CategoryDTO c1)
  {
    c.id=c1.id;
    c.name=c1.name;
  }

}
}


      